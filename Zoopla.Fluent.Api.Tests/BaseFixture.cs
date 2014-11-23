using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoopla.Fluent.Api.Tests
{
    public abstract class BaseFixture
    {
        protected const string OUTCODE_VALID = "GL52";
        protected const string OUTCODE_SHORT_VALID = "GL";
        protected const string OUTCODE_INVALID = "XX50";

        protected const string AREA_VALID = "gloucester";
        protected const string AREA_INVALID = "nonsense";

        protected ZooplaFluentApi Api { get; private set; }
        
        [TestInitialize]
        public void Arrange()
        {
            Api = new ZooplaFluentApi(ConfigurationManager.AppSettings["ZooplaApiKey"]);
        }
    }
}
