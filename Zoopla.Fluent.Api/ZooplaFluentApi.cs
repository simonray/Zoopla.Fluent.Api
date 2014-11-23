using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

using AutoMapper;
using Zoopla.Fluent.Api.Extensions;
using Zoopla.Fluent.Api.Model;
using Zoopla.Fluent.Api.Impl;

namespace Zoopla.Fluent.Api
{
    /// <exclude />
    public sealed partial class ZooplaFluentApi : BaseZooplaApi, IZooplaFluentApi, IDisposable
    {
        #region IDisposable
        /// <summary/>
        public void Dispose() { }
        #endregion

        private bool IncludeImages = false;
        //private QueryType QueryType { get; set; }

        /// <summary>
        /// Constrution of the Api
        /// </summary>
        /// <param name="apiKey">Your allocated Api key</param>
        public ZooplaFluentApi(string apiKey)
            : base(apiKey)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.RecognizePrefixes("num_");
            });

            Mapper.CreateMap<string, System.Uri>().ConvertUsing<StringToUriConverter>();

            Mapper.CreateMap<ZListing, ZooplaListing>()
                .ForMember(dst => dst.FloorPlanUrls, opt => opt.MapFrom(src => src.floor_plan))
                .ForMember(dst => dst.NumberOfFloors, opt => opt.MapFrom(src => src.num_floors))
                .ForMember(dst => dst.NumberOfBathrooms, opt => opt.MapFrom(src => src.num_bathrooms))
                .ForMember(dst => dst.NumberOfReceptionRooms, opt => opt.MapFrom(src => src.num_recepts))
                .ForMember(dst => dst.NumberOfBedrooms, opt => opt.MapFrom(src => src.num_bedrooms))
                .ForMember(dst => dst.PriceChange, src => src
                    .MapFrom(obj => (obj.price_change != null ?
                        string.Join(",", obj.price_change.Select(p => string.Format("{0} - {1}", p.date, p.price))) : string.Empty)));

            Mapper.CreateMap<ZSuggestion, ZooplaSuggestion>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.identifier))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.value));
        }

        #region IPropertySearch
        /// <exclude />
        public IPropertyTypes Sales
        {
            get
            {
                Parameters.Add(ParameterType.ListingStatus.Val(), "sale"); return new PropertyTypes(this);
            }
        }

        /// <exclude />
        public IPropertyTypes Rentals
        {
            get
            {
                Parameters.Add(ParameterType.ListingStatus.Val(), "rent"); return new PropertyTypes(this);
            }
        }

        /// <exclude />
        public IPropertyOptions Specific(int id)
        {
            Parameters.Add(ParameterType.ListingId.Val(), id.ToString());
            return new PropertyOptions(this);
        }

        /// <exclude />
        public IPropertyOptions Specific(int[] ids)
        {
            foreach (int id in ids)
            {
                Parameters.Add(ParameterType.ListingId.Val(), id.ToString());
            }
            return new PropertyOptions(this);
        }

        /// <exclude />
        public IList<ZooplaSuggestion> Suggestions(string term, SearchOption option)
        {
            List<ZooplaSuggestion> locations = new List<ZooplaSuggestion>();
            var results = LocationResults(term, option.Val());
            return Mapper.Map<List<ZSuggestion>, List<ZooplaSuggestion>>(results.suggestions);
        }
        #endregion

        #region IPropertyActions
        /// <exclude />
        public int Count()
        {
            return ExecuteCount();
        }

        /// <exclude />
        public IList<ZooplaListing> Go(int page)
        {
            return ExecuteQuery(page);
        }
        #endregion

        #region IPropertyLocation
        /// <exclude />
        public IPropertyOptions In(InOption option, string location)
        {
            switch (option)
            {
                case InOption.Area:
                    SetOption(ParameterType.Area.Val(), location, OptionType.Once);
                    break;
                case InOption.Postcode:
                    SetOption(ParameterType.Postcode.Val(), location, OptionType.Once);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return new PropertyOptions(this);
        }
        #endregion

        #region Private
        private IPropertyOptions SetOption(string name, string value, OptionType options)
        {
            base.SetParameter(name, value, options);
            return new PropertyOptions(this);
        }

        private bool IsRental()
        {
            return Parameters[ParameterType.ListingStatus.Val()].Equals("rental");
        }

        private bool IsSale()
        {
            return Parameters[ParameterType.ListingStatus.Val()].Equals("sale");
        }

        private void EnsureSaleQuery()
        {
            if (Parameters["listing_id"] == null && IsRental())
                throw new OperationCanceledException(string.Format("You cannot use an option thats specific to sales against a rental query"));
        }

        private void EnsureRentalQuery()
        {
            if (Parameters["listing_id"] == null && IsSale())
                throw new OperationCanceledException(string.Format("You cannot use an option thats specific to rentals against a sale query"));
        }

        private int ExecuteCount()
        {
            //TODO: optimise, reduce page_size, only 1 prop of struct req?
            return PropertyResults().result_count;
        }

        private IList<ZooplaListing> ExecuteQuery(int page)
        {
            SetOption("page_number", page.ToString(), OptionType.Overridable);

            var listings = Mapper.Map<List<ZListing>, List<ZooplaListing>>(PropertyResults().listing);

            if (IncludeImages)
            {
                ObjectCache cache = MemoryCache.Default;
                CacheItemPolicy policy = new CacheItemPolicy() { SlidingExpiration = new TimeSpan(24, 0, 0) };

                foreach (ZooplaListing listing in listings)
                {
                    CacheItem imageUrls = cache.GetCacheItem(listing.ListingId);
                    if (imageUrls != null)
                    {
                        listing.ImageUrls = (List<Uri>)imageUrls.Value;
                    }
                    else
                    {
                        listing.ImageUrls = base.GetImageLinksFromUrl(listing.DetailsUrl).ToList();
                        cache.Set(listing.ListingId, listing.ImageUrls, policy);
                    }
                }
            }

            return listings;
        }
        #endregion
    }
}
