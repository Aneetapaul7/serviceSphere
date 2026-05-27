using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serviceSphere.Models
{
    public class admininsert
    {   
        [Required(ErrorMessage ="enter the name")]
        public string name { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Enter valid email")]
        public string email { get; set; }
        [Required(ErrorMessage = "enter the phone number")]
        [RegularExpression(@"^(\d{10})$",ErrorMessage ="enter valid number")]
        public long phone { get; set; }
        [Required(ErrorMessage = "enter the username")]
        public string username { get; set; }
        public string pass { get; set; }
        [Compare("pass",ErrorMessage ="password mismatch")]
        public string cpassword { get; set; }
        public string adminmsg { get; set; }
    }
}