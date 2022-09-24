using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class Ride
    {
        public int time;
        public double distance;
        public Ride(int time, double distance)
        {
            this.time = time;
            this.distance = distance;
        }

    }
}
