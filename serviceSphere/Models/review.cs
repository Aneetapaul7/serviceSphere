using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serviceSphere.Models
{
    public class review
    {
        public int review_id { get; set; }

        public int booking_id { get; set; }

        public int user_id { get; set; }

        public int service_id { get; set; }

        public int rating { get; set; }

        public string review_msg { get; set; }

        public DateTime created_date { get; set; }
    }
}