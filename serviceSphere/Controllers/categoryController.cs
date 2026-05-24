using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serviceSphere.Models;

namespace serviceSphere.Controllers
{
    public class categoryController : Controller
    {
        servicesphereEntities2 dbobj = new servicesphereEntities2();
        // GET: category
        public ActionResult category_pageload()
        {
            ViewBag.categorylist = dbobj.sp_category_select().ToList();
            return View();
        }

        public ActionResult category_clickinsert(category clsobj)
        {
            if (ModelState.IsValid) { 
            dbobj.sp_category_insert(clsobj.cat_name);
            clsobj.msg = "category added suceessfullyyyy";
            ViewBag.categorylist = dbobj.sp_category_select().ToList();
                return View("category_pageload",clsobj);
            }
            ViewBag.categorylist = dbobj.sp_category_select().ToList();
            return View("category_pageload", clsobj);
        }

        public ActionResult category_delete(int id)
        {
            dbobj.sp_category_delete(id);

            return RedirectToAction("category_pageload");
        }

    }
}