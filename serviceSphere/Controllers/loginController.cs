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
        servicesphereEntities2 dbobj = new servicesphereEntities2();
        // GET: login
        public ActionResult login_pageload()
        {
            return View();
        }


        public ActionResult home()
        {
            return View();
        }



        public ActionResult adminhome()
        {
            return View();
        }

        public ActionResult providerhome()
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
                        return RedirectToAction("providerhome");
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

       
    }
}