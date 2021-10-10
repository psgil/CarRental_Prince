using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental_Prince.Models
{
    public class Fine
    {
        public int ID { get; set; }
        public int CarRental_PrinceID { get; set; }
        public decimal AmountFine { get; set; }
        public decimal FineDeposit { get; set; }
        public DateTime DepositDate { get; set; }

        public CarRental_Prince CarRental_Princes { get; set; }
    }
}