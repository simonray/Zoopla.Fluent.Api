using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoopla.Fluent.Api.Model
{
    /// <summary>
    /// Represents a listing for a specific property
    /// </summary>
    [DebuggerDisplay("{Price} - {DisplayableAddress}")]
    public class ZooplaListing
    {
        /// <summary>
        /// Return a formatted string related to the property
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}", Price, DisplayableAddress);
        }

        /// <summary>
        /// Specific listing status. Either "sale" or "rent".
        /// </summary>
        public ListingStatusOption ListingStatus { get; set; }

        /// <summary>
        /// Get or set the number of floors that this property has.
        /// </summary>
        public string NumberOfFloors { get; set; }

        /// <summary>
        /// Get or set the number of bedrooms that this property has.
        /// </summary>
        public string NumberOfBedrooms { get; set; }

        /// <summary>
        /// Get or set the number of bathrooms that this property has.
        /// </summary>
        public string NumberOfBathrooms { get; set; }

        /// <summary>
        /// Get or set the number of receptions that this property has.
        /// </summary>
        public string NumberOfReceptionRooms { get; set; }

        /// <summary>
        /// Get or set the latitude of the property, if known.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Get or set the longitude coordinate of the property, if known.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Get or set the address of the agent advertising the property
        /// </summary>
        public string AgentAddress { get; set; }

        /// <summary>
        /// Get or set type of property, possible values:
        /// Terraced, End of terrace, Semi-detached, Detached, Mews house, Flat, Maisonette
        /// Bungalow, Town house, Cottage, Farm/Barn, Mobile/static, Land, Studio, Block of flats, Office
        /// </summary>
        public string PropertyType { get; set; }

        /// <summary>
        /// A web address for the thumbnail associated with this property, with a bounding width of 80 pixels
        /// and a height of 60 pixels.
        /// </summary>
        public Uri ThumbnailUrl { get; set; }

        /// <summary>
        /// Url for the main image in large format.
        /// </summary>
        /// <remarks>This is derived and not part of the standard API</remarks>
        public Uri MainImageUrl
        {
            get 
            {
                if (ImageUrl == null) return null;
                return new Uri(ImageUrl.OriginalString.Replace("_354_255", string.Empty).Replace("http://li", "http://lc")); 
            }
        }

        /// <summary>
        /// Get or set the description of the property
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Get or set the name of the town that the property is located within.
        /// </summary>
        public string PostTown { get; set; }

        /// <summary>
        /// Get or set the URL for the full details for this listing on the Zoopla website
        /// </summary>
        public Uri DetailsUrl { get; set; }

        /// <summary>
        /// Get or set the short description of the property, similar to that used in search results.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Get or set the outcode for the property.
        /// </summary>
        public string Outcode { get; set; }

        /// <summary>
        /// Get or set the name of the county that the property is in.
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// The price of this property for listings that have a status of "sale" and a per-week price for 
        /// those that have a status of "rent". If the price modifier value is "price_on_request" the
        /// price will be returned as 0.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Restrictions related to the price of the listing, specifically: 
        /// "offers_over", "poa", "fixed_price", "from", "offers_in_region_of", 
        /// "part_buy_part_rent", "price_on_request", "shared_equity", "shared_ownership", 
        /// "guide_price", "sale_by_tender".
        /// </summary>
        public string PriceModifier { get; set; }

        /// <summary>
        /// Get or set the Zoopla.co.uk unique listing identifier for this property listing.
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// The caption related to the thumbnail and main image provided with this image.
        /// </summary>
        public string ImageCaption { get; set; }

        /// <summary>
        /// The listings's specific status, possible values are: "for_sale", "sale_under_offer",
        /// "sold", "to_rent", "rent_under_offer" and "rented".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The name of the agent that is advertising this listing.
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        /// A URL to a logo that can be used for the agent that is advertising this listing.
        /// </summary>
        public string AgentLogo { get; set; }

        /// <summary>
        /// The phone number that can be used to contact the agent about this listing.
        /// </summary>
        public string AgentPhone { get; set; }

        /// <summary>
        /// The name of the country that the property is in.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The address of the property.
        /// </summary>
        public string DisplayableAddress { get; set; }

        /// <summary>
        /// The date that this listing first appeared on the Zoopla Web site.
        /// </summary>
        public string FirstPublishedDate { get; set; }

        /// <summary>
        ///  	Each floor plan associated with the listing will have a URL appear within a
        ///  	"floor_plan" element of the listing.
        /// </summary>
        public List<Uri> FloorPlanUrls { get; set; }

        /// <summary>
        /// A web address for the main image associated with this property, with a bounding width of
        /// 354 pixels and a height of 255 pixels.
        /// </summary>
        /// <remarks>This is derived and not part of the standard API</remarks>
        public List<Uri> ImageUrls { get; set; }

        /// <summary>
        /// The name of the street that this property is on.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Price change information when it was received by the Zoopla web site.
        /// Key name 	Description
        /// price 	    The new price received for the listing.
        /// date 	    The full date and time that the new price was received (e.g. 2011-02-12 00:31:53)
        /// </summary>
        public string PriceChange { get; set; }

        /// <summary>
        /// A web address for the main image associated with this property, with a bounding width
        /// of 354 pixels and a height of 255 pixels.
        /// </summary>
        public Uri ImageUrl { get; set; }

        /// <summary>
        /// The date that this listing was last amended or updated on Zoopla web site
        /// </summary>
        public string LastPublishedDate { get; set; }
    }
}
