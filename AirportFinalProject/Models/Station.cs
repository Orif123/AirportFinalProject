using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Models
{
    public class Station
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
        public string FlightId { get; set; }
        public string  PhotoPath { get; set; }

    }
}