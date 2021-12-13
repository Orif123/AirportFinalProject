using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Airport.Models
{
    public class Flight
    {
        public string  FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public bool IsDeparture { get; set; }
        [ForeignKey("StationId")]
        public Station? Station { get; set; }
        public int? StationId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public string CompanyId { get; set; }

    }
}
