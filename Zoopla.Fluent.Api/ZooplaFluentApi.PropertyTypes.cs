using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoopla.Fluent.Api.Model;
using Zoopla.Fluent.Api.Extensions;
using Zoopla.Fluent.Api.Impl;

namespace Zoopla.Fluent.Api
{
    public partial class ZooplaFluentApi
    {
        private class PropertyTypes : IPropertyTypes
        {
            private ZooplaFluentApi Impl { get; set; }
            public PropertyTypes(ZooplaFluentApi impl) { Impl = impl; }
      
            public IPropertyLocation OfHouses
            {
                get
                {
                    Impl.SetOption(ParameterType.PropertyType.Val(), "houses", OptionType.Once);
                    return new PropertyLocation(Impl);
                }
            }

            public IPropertyLocation OfFlats
            {
                get
                {
                    Impl.SetOption(ParameterType.PropertyType.Val(), "flats", OptionType.Once);
                    return new PropertyLocation(Impl);
                }
            }

            public IPropertyOptions In(string location)
            {
                return Impl.In(location);
            }

            public IPropertyOptions In(InOption option, string location)
            {
                return Impl.In(option, location);
            }
        }
    }
}
