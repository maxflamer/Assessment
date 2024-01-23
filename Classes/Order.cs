using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Classes
{
    public class Order
    {
        public string? OrderName { get; set; }

        public string? Destination { get; set; }
    }

    public enum Location
    {
        YUL = 0,
        YYZ = 1,
        YYC = 2,
        YVR = 3,
        YYE = 4
    }

}
