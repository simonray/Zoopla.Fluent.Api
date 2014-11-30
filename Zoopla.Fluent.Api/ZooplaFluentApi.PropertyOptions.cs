using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoopla.Fluent.Api.Extensions;
using Zoopla.Fluent.Api.Impl;
using Zoopla.Fluent.Api.Model;

namespace Zoopla.Fluent.Api
{
    public partial class ZooplaFluentApi : IZooplaFluentApi
    {
        private class PropertyOptions : IPropertyOptions
        {
            private ZooplaFluentApi Impl { get; set; }
            public PropertyOptions(ZooplaFluentApi impl) { Impl = impl; }

            #region IPropertyOptions
            public IPropertyOptions Radius(double value)
            {
                return Impl.SetOption(ParameterType.Radius.Val(), Math.Round(value, 2).ToString(), OptionType.Once);
            }

            public IPropertyOptions OrderBy(OrderByOption value)
            {
                switch (value)
                {
                    case OrderByOption.Age:
                    case OrderByOption.Price:
                        return Impl.SetOption(ParameterType.Postcode.Val(), value.Val(), OptionType.Once);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public IPropertyOptions Ordering(OrderingOption value)
            {
                switch (value)
                {
                    case OrderingOption.Ascending:
                    case OrderingOption.Descending:
                        return Impl.SetOption(ParameterType.Ordering.Val(), value.Val(), OptionType.Once);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public IPropertyOptions IncludeSold
            {
                get
                {
                    Impl.EnsureSaleQuery();
                    return Impl.SetOption(ParameterType.IncludeSold.Val(), true.ToYesNoString(), OptionType.Once);
                }
            }

            public IPropertyOptions IncludeLet
            {
                get
                {
                    Impl.EnsureRentalQuery();
                    return Impl.SetOption(ParameterType.IncludeRented.Val(), true.ToYesNoString(), OptionType.Once);
                }
            }

            public IPropertyOptions MinimumPrice(int value)
            {
                return Impl.SetOption(ParameterType.MinimumPrice.Val(), value.ToString(), OptionType.Once);
            }

            public IPropertyOptions MaximumPrice(int value)
            {
                return Impl.SetOption(ParameterType.MaximumPrice.Val(), value.ToString(), OptionType.Once);
            }

            public IPropertyOptions MinimumBeds(int value)
            {
                return Impl.SetOption(ParameterType.MinimumBeds.Val(), value.ToString(), OptionType.Once);
            }

            public IPropertyOptions MaximumBeds(int value)
            {
                return Impl.SetOption(ParameterType.MaximumBeds.Val(), value.ToString(), OptionType.Once);
            }

            public IPropertyOptions Furnished(FurnishedOption value)
            {
                Impl.EnsureRentalQuery();
                switch (value)
                {
                    case FurnishedOption.Furnished:
                    case FurnishedOption.Unfurnished:
                    case FurnishedOption.PartFurnished:
                        return Impl.SetOption(ParameterType.Furnished.Val(), value.Val(), OptionType.Once);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public IPropertyOptions NewHomes
            {
                get { return Impl.SetOption(ParameterType.NewHomes.Val(), true.ToYesNoString(), OptionType.Once); }
            }

            public IPropertyOptions ChainFree
            {
                get { return Impl.SetOption(ParameterType.ChainFree.Val(), true.ToYesNoString(), OptionType.Once); }
            }

            public IPropertyOptions IncludeImages
            {
                get { Impl.IncludeImages = true; return new PropertyOptions(Impl); }
            }

            public IPropertyOptions Keywords(params string[] value)
            {
                return Impl.SetOption(ParameterType.Keywords.Val(), string.Join(" ", value), OptionType.Once);
            }

            public IPropertyOptions SpecificBranch(int branchId)
            {
                return Impl.SetOption(ParameterType.BranchId.Val(), branchId.ToString(), OptionType.Once);
            }

            //public IPropertyOptions PropertyType(PropertyOption value)
            //{
            //    switch (value)
            //    {
            //        case PropertyOption.All:
            //            return this;
            //        case PropertyOption.Houses:
            //        case PropertyOption.Flats:
            //            return Impl.SetOption(ParameterType.PropertyType.Val(), value.Val(), OptionType.Once);
            //        default:
            //            throw new ArgumentOutOfRangeException();
            //    }
            //}

            public IPropertyOptions Summary
            {
                get { return Impl.SetOption(ParameterType.Summarised.Val(), true.ToYesNoString(), OptionType.Once); }
            }

            public IPropertyOptions PageSize(int value)
            {
                return Impl.SetOption(ParameterType.PageSize.Val(), value.ToString(), OptionType.Once);
            }
            #endregion

            #region IPropertyActions
            public int Count()
            {
                return Impl.ExecuteCount();
            }

            public IList<ZooplaListing> Go(int page)
            {
                return Impl.ExecuteQuery(page);
            }
            #endregion
        }
    }
}
