using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serviceSphere.Models
{
    public class service
    {
        public int service_id { get; set; }
        public int provider_regid { get; set; }
        public int category_id { get; set; }
        [Required(ErrorMessage = "enter the name")]
        public string service_name { get; set; }
        [Required(ErrorMessage = "enter the description")]
        public string service_description { get; set; }
        [Required(ErrorMessage = "enter the price")]
        public int service_price { get; set; }
        public string service_image { get; set; }
        public string service_status { get; set; }
        public string location { get; set; }
        // FILE UPLOAD
        [Required(ErrorMessage = "select image")]
        public HttpPostedFileBase file { get; set; }
        public string msg { get; set; }
    }
}