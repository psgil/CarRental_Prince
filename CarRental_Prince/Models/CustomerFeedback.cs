using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental_Prince.Models
{
    public class CustomerFeedback
    {

        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string Feedback { get; set; }

        public Customer Customer { get; set; }

    }
}
