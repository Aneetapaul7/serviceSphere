using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serviceSphere.Models
{
    public class category
    {
        public int cat_id { get; set; }
        [Required(ErrorMessage = "enter the categoryname")]
        public string cat_name { get; set; }
        public string msg { get; set; }
    }
}