using Airport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AirportFinalProject.Models
{
    public class FlightHistory
    {
        [Key]
        public string FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public bool IsDeparture { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public string CompanyId { get; set; }
    }
}
