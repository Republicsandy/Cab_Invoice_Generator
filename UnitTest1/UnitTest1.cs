using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cab_Invoice_Generator;

namespace UnitTest1
{
    [TestClass]
    internal class Tests
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
        //Test case for time less than or equal to zero
        [TestMethod]
        [TestCategory("Calculate for invalid Time Premium Ride")]
        public void InvalidTimeCalculateTotalFareForPremiumRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
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
        //UC2:Calculate aggregate fare for normal ride
        [TestMethod]
        [TestCategory("Calculate Aggregate Fare for normal ride")]
        public void CalculateAggregateFare()
        {
            CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
            Ride[] ride = { new Ride(3, 5.0), new Ride(6, 7.0) };
            double actual = calculate.CalculateAggregateFare(ride);
            double expected = 129.0;
            Assert.AreEqual(expected, actual);

        }
        //TC2.1:Calculate aggregate fare for premium ride
        [TestMethod]
        [TestCategory("Calculate Aggregate Fare for Premium ride")]
        public void CalculateAggregateFareForPremiumRide()
        {
            CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
            Ride[] ride = { new Ride(3, 5.0), new Ride(6, 7.0) };
            double actual = calculate.CalculateAggregateFare(ride);
            double expected = 198.0;
            Assert.AreEqual(expected, actual);
        }
        //TC2.2:Invalid Ride List Count
        [TestMethod]
        [TestCategory("Invalid Ride List")]
        public void InvalidRideList()
        {
            try
            {
                CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
                Ride[] ride = { };
                calculate.CalculateAggregateFare(ride);
            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Ivalid Ride List";
                Assert.AreEqual(ex.Message, expected);
            }
        }
    }
}