using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cab_Invoice_Generator;

namespace UnitTest1
{
    [TestClass]
    public class Tests
    {
        //UC1.1:Calculates the fare for normal ride
        [TestMethod]
        [TestCategory("Calculate Fare For Normal Ride")]
        public void CalculateTotalFareForNormalRide()
        {
            CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
            double distance = 4.8;
            int time = 20;
            double fare = cabInvoiceCalculate.CalculateFare(time, distance);
            double expected = 68.0;
            Assert.AreEqual(expected, fare);

        }
        //Test case for distance less than or equal to zero
        [TestMethod]
        [TestCategory("Calculate for invalid distance")]
        public void InvalidDistanceCalculateTotalFareForNormalRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
                double distance = 0;
                int time = 12;
                cabInvoiceCalculate.CalculateFare(time, distance);

            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Distance should be greater than zero";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //Test case for time less than or equal to zero
        [TestMethod]
        [TestCategory("Calculate for invalid Time")]
        public void InvalidTimeCalculateTotalFareForNormalRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
                double distance = 12;
                int time = 0;
                cabInvoiceCalculate.CalculateFare(time, distance);

            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Time should be greater than zero";
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}