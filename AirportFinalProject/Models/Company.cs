using System.Collections;
using System.Collections.Generic;

namespace Airport.Models
{
    public class Company
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string AirplanePath { get; set; }
        public ICollection<Flight> Flights { get; set; }


    }
}