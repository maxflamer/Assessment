using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Classes
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public Location Departure { get; set; }
        public Location Arrival { get; set; }
        public int Day { get; set; }
        public int Capacity { get; set; }

    }
}
