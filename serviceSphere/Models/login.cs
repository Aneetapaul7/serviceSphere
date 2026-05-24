using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serviceSphere.Models
{
    public class login
    {
        [Required(ErrorMessage = "enter the USERNAME")]
        public string username { get; set; }
        [Required(ErrorMessage = "enter the password")]
        public string password { get; set; }
        public string msg { get; set; }


    }
}