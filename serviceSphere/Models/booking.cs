using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serviceSphere.Models
{
    public class booking
    {
        
        public int service_id { get; set; }

        public int provider_id { get; set; }

        public DateTime service_date { get; set; }

        public string service_time { get; set; }

        public string address { get; set; }

        public string description { get; set; }
    }
}