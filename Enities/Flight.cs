using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Flight
    {
        [Required]
        public int FlightId { get; set; }
        [Required]
        public string AitcraftType { get; set; }
        [Required]
        public string FromLocation { get; set; }
        [Required]
        public string ToLocation { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }

    }
}
