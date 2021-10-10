﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental_Prince.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string CarName { get; set; }
        public int CarCategoryID { get; set; }
        public int CarTypeID { get; set; }

        public CarType CarType { get; set; }
        public CarCategory CarCategory { get; set; }

        public List<CarRental_Prince> CarRental_Princes { get; set; }

    }
}