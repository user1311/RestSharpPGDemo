using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpLib;
using RestSharpLib.Models;
using System;

namespace RestSharpPGDemo
{
    [TestClass]
    public class NBPActionsTest
    {
        #region Init
        private static NBPService _nbpService;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _nbpService = new NBPService();
        }
        #endregion

        #region Tests

        /// <summary>
        /// Tests with REST UsersService and RestSharp Json Deserializer
        /// </summary>

        [TestMethod]
        public void GetGoldPrices()
        {
            //Execute reqzest
            var response = _nbpService.GetCenaZlota();
            //Get response data
            var goldPrices = response.Data;
            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DateTime.Now.ToString("yyyy-MM-dd"), response.Data.Data);
            Assert.IsInstanceOfType(response.Data.Cena, typeof(double));
        }

        [TestMethod]
        public void GetGoldPricesInTimeRange()
        {
            var response = _nbpService.GetGoldPricesInTimeRange("2021-03-01","2021-03-15");
            var prices = response.Data;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(response.Data.Count > 0);
        }

        [TestMethod]
        public void GetCurrentExchangeRatesForCHF()
        {
            var response = _nbpService.GetCurrentExchangeRates("CHF");
            var currentRates = response.Data;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.AreEqual("frank szwajcarski", currentRates.Currency);
        }
        #endregion
    }
}
