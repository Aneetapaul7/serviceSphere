using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serviceSphere.Models;

namespace serviceSphere.Controllers
{
    public class reviewController : Controller
    {
        servicesphereEntities dbobj = new servicesphereEntities();
        // GET: review
        public ActionResult AddReview(int booking_id)
        {
            ViewBag.BookingId = booking_id;

            return View();
        }


        [HttpPost]
        public ActionResult AddReview(int booking_id,
                                      int service_id,
                                      int rating,
                                      string review_message)
        {
            int user_id = Convert.ToInt32(Session["uid"]);

            dbobj.sp_add_review(
                booking_id,
                user_id,
                service_id,
                rating,
                review_message
            );

            return RedirectToAction("MyBookings", "booking");
        }


        public ActionResult ProviderReviews()
        {
            int provider_id = Convert.ToInt32(Session["uid"]);

            var data = dbobj.sp_provider_reviews(provider_id).ToList();

            return View(data);
        }

    }
}