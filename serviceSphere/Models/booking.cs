using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serviceSphere.Models
{
    public class booking
    {  
        public int service_id { get; set; }
        public int provider_id { get; set; }
        [Required(ErrorMessage = "enter the Date ")]
        public DateTime service_date { get; set; }
        [Required(ErrorMessage = "enter the Time")]
        public string service_time { get; set; }
        [Required(ErrorMessage = "enter the Address")]
        public string address { get; set; }
        public string description { get; set; }
    }
}