using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoopla.Fluent.Api.Impl
{
    internal enum OptionType
    {
        Once,
        Overridable,
        Multple,
    }

    internal enum ParameterType
    {
        [Description("listing_status")]
        ListingStatus,
        [Description("listing_id")]
        ListingId,
        [Description("area")]
        Area,
        [Description("postcode")]
        Postcode,
        [Description("radius")]
        Radius,
        [Description("order_by")]
        OrderBy,
        [Description("ordering")]
        Ordering,
        [Description("include_sold")]
        IncludeSold,
        [Description("include_rented")]
        IncludeRented,
        [Description("minimum_price")]
        MinimumPrice,
        [Description("maximum_price")]
        MaximumPrice,
        [Description("minimum_beds")]
        MinimumBeds,
        [Description("maximum_beds")]
        MaximumBeds,
        [Description("furnished")]
        Furnished,
        [Description("new_homes")]
        NewHomes,
        [Description("chain_free")]
        ChainFree,
        [Description("keywords")]
        Keywords,
        [Description("branch_id")]
        BranchId,
        [Description("property_type")]
        PropertyType,
        [Description("summarised")]
        Summarised,
        [Description("page_size")]
        PageSize,
    }

    #region AutoCompleteResponse
    [DebuggerDisplay("{identifier}, {value}")]
    internal class ZSuggestion
    {
        public string identifier { get; set; }
        public string value { get; set; }
    }

    [DebuggerDisplay("result = {suggestions.Count}")]
    internal class RootGeoAutocomplete
    {
        public string area_name { get; set; }
        public string street { get; set; }
        public List<ZSuggestion> suggestions { get; set; }
        public string county { get; set; }
        public string town { get; set; }
        public string postcode { get; set; }
    }
    #endregion

    #region ListingResponse
    internal class ZBoundingBox
    {
        public string longitude_min { get; set; }
        public string latitude_min { get; set; }
        public string longitude_max { get; set; }
        public string latitude_max { get; set; }
    }

    [DebuggerDisplay("{listing_id}, {post_town}")]
    internal class ZListing
    {
        public string num_floors { get; set; }
        public string listing_status { get; set; }
        public string num_bedrooms { get; set; }
        public double latitude { get; set; }
        public string agent_address { get; set; }
        public string property_type { get; set; }
        public double longitude { get; set; }
        public string thumbnail_url { get; set; }
        public string description { get; set; }
        public string post_town { get; set; }
        public string details_url { get; set; }
        public string short_description { get; set; }
        public string outcode { get; set; }
        public string county { get; set; }
        public string price { get; set; }
        public string listing_id { get; set; }
        public string image_caption { get; set; }
        public string status { get; set; }
        public string agent_name { get; set; }
        public string num_recepts { get; set; }
        public string country { get; set; }
        public string displayable_address { get; set; }
        public string first_published_date { get; set; }
        public string price_modifier { get; set; }
        public List<string> floor_plan { get; set; }
        public string street_name { get; set; }
        public string num_bathrooms { get; set; }
        public List<ZPriceChange> price_change { get; set; }
        public string agent_logo { get; set; }
        public string agent_phone { get; set; }
        public string image_url { get; set; }
        public string last_published_date { get; set; }
    }

    [DebuggerDisplay("{date}, {price}")]
    internal class ZPriceChange
    {
        public string date { get; set; }
        public string price { get; set; }
    }

    internal class RootPropertyListings
    {
        public string country { get; set; }
        public int result_count { get; set; }
        public double longitude { get; set; }
        public string area_name { get; set; }
        public List<ZListing> listing { get; set; }
        public string street { get; set; }
        public string town { get; set; }
        public double latitude { get; set; }
        public string county { get; set; }
        public ZBoundingBox bounding_box { get; set; }
        public string postcode { get; set; }
    }
    #endregion
}
