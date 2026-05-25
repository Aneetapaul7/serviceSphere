using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serviceSphere.Models;

namespace serviceSphere.Controllers
{
    public class adminregController : Controller
    {
        servicesphereEntities dbobj = new servicesphereEntities();
        // GET: adminreg
        public ActionResult insertadmin_pageload()
        {
            return View();
        }

        public ActionResult insertadmin_click(admininsert clsobj)
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

                dbobj.sp_adminregister(regid, clsobj.name, clsobj.email, clsobj.phone);
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.pass,"admin");
                clsobj.adminmsg = "sucessfully inserted";
                return View("insertadmin_pageload", clsobj);


            }
            return View("insertadmin_pageload", clsobj);

        }

        public ActionResult viewproviders()
        {
            ViewBag.pending =
                dbobj.sp_get_pending_providers().ToList();

            ViewBag.approved =
                dbobj.sp_get_approved_providers().ToList();

            ViewBag.blocked =
                dbobj.sp_get_blocked_providers().ToList();

            return View();
        }




        public ActionResult approve_provider(int id)
        {
            dbobj.sp_approve_provider(id);

            return RedirectToAction("viewproviders");
        }


        public ActionResult block_provider(int id)
        {
            dbobj.sp_block_provider(id);

            return RedirectToAction("viewproviders");
        }

        public ActionResult unblock_provider(int id)
        {
            dbobj.sp_unblock_provider(id);

            return RedirectToAction("viewproviders");
        }



    }
}