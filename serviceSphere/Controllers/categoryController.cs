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
            return View();
        }

        public ActionResult category_clickinsert(category clsobj)
        {
            if (ModelState.IsValid) { 
            dbobj.sp_category_insert(clsobj.cat_name);
            clsobj.msg = "category added suceessfullyyyy";
            return View("category_pageload",clsobj);
            }

            return View("category_pageload", clsobj);
        }



    }
}