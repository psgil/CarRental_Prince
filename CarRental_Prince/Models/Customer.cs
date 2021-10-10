﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental_Prince.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DriingLicenseNo { get; set; }

        public List<CarRental_Prince> CarRental_Princes { get; set; }
        public List<CustomerFeedback> CustomerFeedbacks { get; set; }
    }
}