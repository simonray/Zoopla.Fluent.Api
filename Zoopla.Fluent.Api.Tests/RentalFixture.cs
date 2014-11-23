using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Zoopla.Fluent.Api.Model;

namespace Zoopla.Fluent.Api.Tests
{
    [TestClass]
    public class RentalFixture : BaseFixture
    {
        [TestMethod]
        public void Rental_ValidArea_ReturnsFilledList()
        {
            var listings = Api.Rentals
                .In(InOption.Area, AREA_VALID)
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }

        [TestMethod]
        public void Rental_UnknownArea_ReturnsEmptyList()
        {
            var listings = Api.Rentals
                .In(InOption.Area, AREA_INVALID)
                .Go();
            Assert.AreEqual(listings.Count, 0);
        }

        [TestMethod]
        public void Rental_Furnished_ReturnsFilledList()
        {
            var listings = Api.Rentals
                .In(InOption.Area, AREA_VALID)
                .Furnished(FurnishedOption.Furnished)
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }

        [TestMethod]
        public void Rental_Unfurnished_ReturnsFilledList()
        {
            var listings = Api.Rentals
                .In(InOption.Area, AREA_VALID)
                .Furnished(FurnishedOption.Unfurnished)
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }

        [TestMethod]
        public void Rental_PartFurnished_ReturnsFilledList()
        {
            var listings = Api.Rentals
                .In(InOption.Area, AREA_VALID)
                .Furnished(FurnishedOption.PartFurnished)
                .Go();
            Assert.AreNotEqual(listings.Count, 0);
        }

        [TestMethod]
        public void Rental_ValidRentalQuery_ReturnsOnlyRentals()
        {
            var listings = Api.Rentals
                .In(InOption.Postcode, OUTCODE_VALID)
                .Go();

            listings.All( l => {
                Assert.AreEqual(l.ListingStatus, ListingStatusOption.Rent);
                return true;
            });
        }
    }
}
