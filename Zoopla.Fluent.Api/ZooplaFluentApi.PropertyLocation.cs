using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoopla.Fluent.Api.Model;
using Zoopla.Fluent.Api.Extensions;

namespace Zoopla.Fluent.Api
{
    public partial class ZooplaFluentApi : IZooplaFluentApi
    {
        private class PropertyLocation : IPropertyLocation
        {
            private ZooplaFluentApi Impl { get; set; }
            public PropertyLocation(ZooplaFluentApi impl) { Impl = impl; }

            public IPropertyOptions In(string location)
            {
                return Impl.In(location);
            }

            public IPropertyOptions In(Model.InOption option, string location)
            {
                return Impl.In(option, location);
            }
        }
    }
}
