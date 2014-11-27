using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Zoopla.Fluent.Api.Model;

namespace Zoopla.Fluent.Api.Tests
{
    [TestClass]
    public class SalesFixture : BaseFixture
    {
        [TestMethod]
        public void Sales_ValidInArea_ReturnsFilledList()
        {
            var listings = Api.Sales
                .In(AREA_VALID)
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }

        [TestMethod]
        public void Sales_ValidInPostcode_ReturnsFilledList()
        {
            var listings = Api.Sales
                .In(OUTCODE_VALID)
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }
        
        [TestMethod]
        public void Sales_ValidArea_ReturnsFilledList()
        {
            var listings = Api.Sales
                .In(InOption.Area, AREA_VALID)
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }

        [TestMethod]
        public void Sales_ValidPostcode_ReturnsFilledList()
        {
            var listings = Api.Sales
                .In(InOption.Postcode, OUTCODE_VALID)
                .IncludeImages
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }

        [TestMethod]
        public void Sales_ValidSalesQuery_ReturnsOnlySales()
        {
            var listings = Api.Sales
                .In(InOption.Postcode, OUTCODE_VALID)
                .Go();

            listings.All(l =>
            {
                Assert.AreEqual(l.ListingStatus, ListingStatusOption.Sale);
                return true;
            });
        }
        
        [TestMethod]
        public void Sales_WithImages_ReturnsFilledList()
        {
            var listings = Api.Sales
                .In(InOption.Area, AREA_VALID)
                .IncludeImages
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }

        #region RENTAL ONLY SETTABLE PROPERTIES
        [TestMethod]
        [ExpectedException(typeof(OperationCanceledException))]
        public void Sales_RentalFurnishedProperty_Throws()
        {
            var listings = Api.Sales
                .In(InOption.Area, AREA_VALID)
                .Furnished(FurnishedOption.PartFurnished)
                .Go();
        }

        [TestMethod]
        [ExpectedException(typeof(OperationCanceledException))]
        public void Sales_RentalIncludeLetProperty_Throws()
        {
            var listings = Api.Sales
                .In(InOption.Area, AREA_VALID)
                .IncludeLet
                .Go();
        }
        #endregion

    }
}
