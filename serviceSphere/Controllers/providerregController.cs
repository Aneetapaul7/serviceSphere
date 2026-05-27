using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serviceSphere.Models;

namespace serviceSphere.Controllers
{
    public class providerregController : Controller
    {
        servicesphereEntities dbobj = new servicesphereEntities();
        public ActionResult provider_pageload()
        {
            return View();
        }
        public ActionResult provider_click(serviceprovider clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_maxidlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_providersregister(regid, clsobj.name, clsobj.address, clsobj.email, clsobj.phone, "pending");
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.pass, "serviceprovider");
                clsobj.msg = "sucessfully inserted";
                return View("provider_pageload", clsobj);
            }

            return View("provider_pageload", clsobj);
        }
    }
}