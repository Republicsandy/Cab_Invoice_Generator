using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    internal class InvoiceSummary
    {
        public int numOfRides;
        public double totalFare;
        public double avgFare;

        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.avgFare = totalFare / numOfRides;
        }
        public override string ToString()
        {
            return "\nNo of rides: " + this.numOfRides + " \nTotal Fare: " + this.totalFare + " \nAverage Fare: " + this.avgFare;
        }
    }
}
