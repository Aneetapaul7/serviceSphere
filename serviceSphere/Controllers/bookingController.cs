using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace serviceSphere.Controllers
{
    public class bookingController : Controller
    {
        servicesphereEntities dbobj = new servicesphereEntities();
        // GET: booking
        public ActionResult BookService(int service_id, int provider_id)
        {
            booking obj = new booking();

            obj.service_id = service_id;
            obj.provider_id = provider_id;

            var service = dbobj.servicetabs
                               .FirstOrDefault(x => x.service_id == service_id);

            ViewBag.ServiceName = service.service_name;

            return View(obj);
        }



        [HttpPost]
        public ActionResult BookService(booking obj)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "userreg");
            }

            int user_id = Convert.ToInt32(Session["uid"]);

            dbobj.sp_book_service(
                user_id,
                obj.service_id,
                obj.provider_id,
                obj.service_date,
                obj.service_time,
                obj.address,
                obj.description
            );

            return RedirectToAction("MyBookings");
        }

        public ActionResult MyBookings()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "userreg");
            }

            int user_id = Convert.ToInt32(Session["uid"]);

            var data = dbobj.sp_my_bookings(user_id).ToList();

            return View(data);
        }

        public ActionResult ProviderBookings()
        {
            int provider_id = Convert.ToInt32(Session["uid"]);

            var data = dbobj.sp_provider_bookings(provider_id).ToList();

            return View(data);
        }

        public ActionResult AcceptBooking(int booking_id)
        {
            dbobj.sp_accept_booking(booking_id);
            return RedirectToAction("ProviderBookings");
        }

        public ActionResult RejectBooking(int booking_id)
        {
            dbobj.sp_reject_booking(booking_id);
            return RedirectToAction("ProviderBookings");
        }

        public ActionResult CompleteBooking(int booking_id)
        {
            dbobj.sp_complete_booking(booking_id);
            return RedirectToAction("ProviderBookings");
        }

    }
}