using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class FlightDTO
    {
        public int FlightId { get; set; }
        public string AitcraftType { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
