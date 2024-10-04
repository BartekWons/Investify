using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Investify.MVVM.Model.Stock.Tests
{
    [TestFixture()]
    public class StockOperationsTests
    {
        [Test()]
        public void CountPercentageChangeTest_CorrectResult1()
        {
            double currentPrice = 340.0;
            double previousClose = 338.2;
            var result = StockOperations.CountPercentageChange(previousClose, currentPrice);
            Assert.AreEqual(0.53, result);
        }

        [Test()]
        public void CountPercentageChangeTest_CorrectResult2()
        {
            double currentPrice = 170.50;
            double previousClose = 167.80;
            var result = StockOperations.CountPercentageChange(previousClose, currentPrice);
            Assert.AreEqual(1.61, result);
        }

        [Test()]
        public void CountPercentageChangeTest_CorrectResult3()
        {
            double currentPrice = 142.1;
            double previousClose = 140.75;
            var result = StockOperations.CountPercentageChange(previousClose, currentPrice);
            Assert.AreEqual(0.96, result);
        }

        [Test()]
        public void CountPercentageChangeTest_CorrectResult4()
        {
            double currentPrice = 57.7;
            double previousClose = 57.45;
            var result = StockOperations.CountPercentageChange(previousClose, currentPrice);
            Assert.AreEqual(0.44, result);
        }

        [Test()]
        public void CountPercentageChangeTest_CorrectResult5()
        {
            double currentPrice = 63.3;
            double previousClose = 63.4;
            var result = StockOperations.CountPercentageChange(previousClose, currentPrice);
            Assert.AreEqual(-0.16, result);
        }
    }
}