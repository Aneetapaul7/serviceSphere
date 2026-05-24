using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serviceSphere.Models;

namespace serviceSphere.Controllers
{   
 
    public class userregController : Controller
    {
        servicesphereEntities2 dbobj = new servicesphereEntities2();
        // GET: userreg
        public ActionResult userreg_pageload()
        {
            return View();
        }

        public ActionResult userreg_click(userinsert clsobj)
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

                dbobj.sp_userregister(regid, clsobj.name, clsobj.address,clsobj.phone, clsobj.email, "active");
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "sucessfully inserted";
                return View("userreg_pageload", clsobj);
            }

            return View("userreg_pageload", clsobj);
        }
    }
}