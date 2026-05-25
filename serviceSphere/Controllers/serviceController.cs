using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serviceSphere.Models;
using System.IO;
namespace serviceSphere.Controllers
{
    public class serviceController : Controller
    {
        servicesphereEntities dbobj = new servicesphereEntities();
        // GET: service
        public ActionResult service_pageload()
        {

            List<SelectListItem> cat = dbobj.categorytabs
              .Select(c => new SelectListItem
              {
                  Text = c.catname,
                  Value = c.catid.ToString()
              }).ToList();

            ViewBag.category = cat;
            return View();
        }

        [HttpPost]
        public ActionResult service_click(service clsobj)
        {


            // RELOAD CATEGORY DROPDOWN

            List<SelectListItem> cat = dbobj.categorytabs
                .Select(c => new SelectListItem
                {
                    Text = c.catname,
                    Value = c.catid.ToString()
                }).ToList();

            ViewBag.category = cat;

            if (ModelState.IsValid)
            {
                int pid = Convert.ToInt32(Session["uid"]);


                // IMAGE UPLOAD

                if (clsobj.file != null && clsobj.file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(clsobj.file.FileName);

                    // FOLDER PATH

                    string folder = Server.MapPath("~/photos/");

                    // CREATE FOLDER IF NOT EXISTS

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    // FULL PATH

                    string fullpath = Path.Combine(folder, fname);

                    // SAVE IMAGE

                    clsobj.file.SaveAs(fullpath);

                    // SAVE IMAGE NAME TO DATABASE

                    clsobj.service_image = fname;
                }


                dbobj.sp_insert_service(
                    pid,
                    clsobj.category_id,
                    clsobj.service_name,
                    clsobj.service_description,
                    clsobj.service_price,
                    clsobj.service_image,
                    "Available",
                      clsobj.location);
                clsobj.msg = "sucessfully inserted";
                return View("service_pageload", clsobj);
            }
            else
            {
                
                
                    clsobj.msg = "Validation failed";
                
            }

            return View("service_pageload",clsobj);
        }


        public ActionResult viewservice()
        {
            int pid = Convert.ToInt32(Session["uid"]);

            var data = dbobj.sp_view_provider_services(pid).ToList();

            return View(data);
        }

        public ActionResult delete_service(int id)
        {
            dbobj.sp_delete_service(id);

            return RedirectToAction("viewservice");
        }


    }
}