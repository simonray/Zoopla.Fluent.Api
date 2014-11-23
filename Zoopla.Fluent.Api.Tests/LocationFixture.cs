using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Zoopla.Fluent.Api.Model;

namespace Zoopla.Fluent.Api.Tests
{
    [TestClass]
    public class LocationFixture : BaseFixture
    {
        [TestMethod]
        public void Location_Search_Has_Results()
        {
            IList<ZooplaSuggestion> areaValid = Api.Suggestions(AREA_VALID, SearchOption.SaleOrRentals);
            Assert.AreNotEqual(areaValid.Count, 0);
        }

        [TestMethod]
        public void Location_Search_No_Results()
        {
            IList<ZooplaSuggestion> areaInvalid = Api.Suggestions(AREA_INVALID, SearchOption.SaleOrRentals);
            Assert.AreEqual(areaInvalid.Count, 0);
        }
    }
}
