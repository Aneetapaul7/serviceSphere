using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serviceSphere.Models;

namespace serviceSphere.Controllers
{
    public class loginController : Controller
    {
        servicesphereEntities dbobj = new servicesphereEntities();
        public ActionResult login_pageload()
        {
            return View();
        }
        public ActionResult login_click(login clsobj)
        {
            if (ModelState.IsValid)
            {
                var val = dbobj.sp_logincountid(clsobj.username, clsobj.password).First();

                if (val == 1)
                {
                    var uid = dbobj.sp_logid(clsobj.username, clsobj.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_logintype(clsobj.username, clsobj.password).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("home");
                    }
                    else if (lt == "admin")
                    {
                        return RedirectToAction("adminhome");
                    }
                    else if (lt == "serviceprovider")
                    {
                        var status = dbobj.sp_check_provider_status(uid).FirstOrDefault();
                        if (status == "pending")
                        {
                            ModelState.Clear();
                            clsobj.msg = "Waiting for admin approval";

                            return View("login_pageload", clsobj);
                        }

                        else if (status == "blocked")
                        {
                            ModelState.Clear();
                            clsobj.msg = "Your account is blocked by admin";

                            return View("login_pageload", clsobj);
                        }

                        else if (status == "approved")
                        {
                          
                            return RedirectToAction("providerhome");
                        }
                    }
                }
                else
                {
                    ModelState.Clear();
                    clsobj.msg = "invalid username password...";
                    return View("login_pageload", clsobj);
                }
            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "invalid login";
            }
            return View("login_pageload", clsobj);
        }
        public ActionResult home()
        {
            ViewBag.categories = dbobj.categorytabs.ToList();

            var services = dbobj.sp_get_all_services().ToList();

            return View(services);
        }








        [HttpPost]
        public ActionResult search_service(
            string service_name,
            string provider_name,
            string location,
            string category)
        {
            ViewBag.categories = dbobj.categorytabs.ToList();

            ViewBag.service_name = service_name;
            ViewBag.provider_name = provider_name;
            ViewBag.location = location;
            ViewBag.category = category;

            var data = dbobj.sp_get_all_services().ToList();

            if (!string.IsNullOrWhiteSpace(service_name))
            {
                data = data.Where(x =>
                    x.service_name != null &&
                    x.service_name.ToLower().Contains(service_name.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(provider_name))
            {
                data = data.Where(x =>
                    x.bussiness_name != null &&
                    x.bussiness_name.ToLower().Contains(provider_name.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                data = data.Where(x =>
                    x.location != null &&
                    x.location.ToLower().Contains(location.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                data = data.Where(x =>
                    x.catname != null &&
                    x.catname == category)
                    .ToList();
            }

            if (data.Count == 0)
            {
                ViewBag.msg = "No services found";
            }

            return View("home", data);
        }



        public ActionResult adminhome()
        {
            return View();
        }
        public ActionResult providerhome()
        {
            return View();
        }
    }
}