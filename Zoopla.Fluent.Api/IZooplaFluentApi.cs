using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoopla.Fluent.Api.Model;

namespace Zoopla.Fluent.Api
{
    /// <summary>
    /// Provides property searching and location suggestion services using the Zoopla API
    /// </summary>
    public interface IZooplaFluentApi : IFluent, IPropertySearch { }

    /// <summary>
    /// Provides methods to support the type of property search that will be performed
    /// </summary>
    public interface IPropertySearch : IFluent, IPropertyActions
    {
        /// <summary>
        /// Specify that the search will be on properties for sale
        /// </summary>
        IPropertyTypes Sales { get; }

        /// <summary>
        /// Specify that the search will be on rental properties to let
        /// </summary>
        IPropertyTypes Rentals { get; }

        /// <summary>
        /// Specify a specifc property that will the search will be performed on
        /// </summary>
        /// <param name="id">Zoopla property Id</param>
        /// <returns>Options and actions that can be applied for the selected property</returns>
        IPropertyOptions Specific(int id);

        /// <summary>
        /// Specify a specifc property(s) that will the search will be performed on
        /// </summary>
        /// <param name="id">Zoopla property Id(s)</param>
        /// <returns>Options and actions that can be applied for the selected properties</returns>
        IPropertyOptions Specific(int[] id);

        /// <summary>
        /// Get a list of auto-suggestions for a given location (location, part-location, postcode, etc)
        /// </summary>
        /// <param name="term">A string holding the search term to be auto completed</param>
        /// <param name="option">Option for search a particular catalog to autocomplete on.
        /// Listings (for sale, rent) or Properties (sold and current).
        /// </param>
        /// <returns>List of suggestions or an empty list if none found.</returns>
        /// <example>
        ///     IList&lt;Suggestion&gt; locations = Api.Suggestions("ruislip", SearchOption.Listings);
        /// </example>
        IList<ZooplaSuggestion> Suggestions(string term, SearchOption option);
    }

    /// <summary>
    /// Represents available methods for the type of property to be searched
    /// </summary>
    public interface IPropertyTypes : IFluent, IPropertyLocation
    {
        /// <summary>
        /// Specify the query will be against houses only
        /// </summary>
        IPropertyLocation OfHouses { get; }
        /// <summary>
        /// Specify the query will be against flats only
        /// </summary>
        IPropertyLocation OfFlats { get; }
    }

    /// <summary>
    /// Represents the available methods to determine the search area criteria
    /// </summary>
    public interface IPropertyLocation : IFluent
    {
        /// <summary>
        /// Indicate a post code or location to which the query will be applyed to.
        /// </summary>
        /// <param name="location">Postcode (full or partial) or area</param>
        /// <returns></returns>
        IPropertyOptions In(string location);

        /// <summary>
        /// Indicate the location where the query will be applyed to.
        /// </summary>
        /// <param name="option">Area or Postcode</param>
        /// <param name="location">Full or partial area or postcode/outcode</param>
        /// <returns></returns>
        IPropertyOptions In(InOption option, string location);
    }

    /// <summary>
    /// Represents the available options to narrow the search
    /// </summary>
    public interface IPropertyOptions : IFluent, IPropertyActions
    {
        /// <summary>
        /// Include the radius from the search location to find listings. The default value is 0.5 miles with
        /// a maximum radius of 40 miles.
        /// </summary>
        /// <param name="value">Number of miles radius</param>
        /// <returns>A fluent query where addtional options chained and executed</returns>
        IPropertyOptions Radius(double value);

        /// <summary>
        /// Specify the ordering used for any listing results (default is price)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IPropertyOptions OrderBy(OrderByOption value);

        /// <summary>
        /// Sort order for the listings returned. Either descending (default) or ascending.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IPropertyOptions Ordering(OrderingOption value);

        /// <summary>
        /// Indicate that you require sold properties to be included in query. This is applicable only to sales.
        /// </summary>
        /// <remarks>
        /// The default is false if not specified
        /// </remarks>
        IPropertyOptions IncludeSold { get; } //TODO: Refactor - sales options interface?

        /// <summary>
        /// Indicate that you require let properties to be included in query. This is applicable only to rentals.
        /// </summary>
        /// <remarks>
        /// The default is false if not specified
        /// </remarks>
        IPropertyOptions IncludeLet { get; } //TODO: Refactor - rental options interface?

        /// <summary>
        /// Set the minimum price of properties to be included in the query. For a "Sale" this is the sale
        /// price and for "Rented" this is referes to the per-week price.
        /// </summary>
        /// <param name="value">Amount in GBP</param>
        /// <returns></returns>
        IPropertyOptions MinimumPrice(int value);

        /// <summary>
        /// Set the maximum price of properties to be included in the query
        /// </summary>
        /// <param name="value">Amount in GBP</param>
        /// <returns></returns>
        IPropertyOptions MaximumPrice(int value);

        /// <summary>
        /// Set the minimum number of bedrooms the property should have.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IPropertyOptions MinimumBeds(int value);

        /// <summary>
        /// Set the maximum number of bedrooms the property should have.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IPropertyOptions MaximumBeds(int value);

        /// <summary>
        /// Specify whether or not the apartment is furnished, unfurnished or part-furnished. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>NOTE:  This parameter only applies to searches related to rental property.</remarks>
        IPropertyOptions Furnished(FurnishedOption value);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //IPropertyOptions PropertyType(PropertyOption value); //delete and enum - use property instead

        /// <summary>
        /// Specify that the query will be restricted the query to new homes only
        /// </summary>
        /// <remarks>NOTE: Default is ALL</remarks>
        IPropertyOptions NewHomes { get; }

        /// <summary>
        /// Specify that the query will be restricted the query to chain-free homes only
        /// </summary>
        /// <remarks>NOTE: Default is ALL</remarks>
        IPropertyOptions ChainFree { get; }

        /// <summary>
        /// Indicate that you require all of the image links for the property to be retrieved in query
        /// </summary>
        /// <remarks>NOTE: This is not functionality of the original API. To obtain these the source page
        /// is scrapped and links derived. This can be SLOW, approximately 1sec per property (using compression)</remarks>
        IPropertyOptions IncludeImages { get; }

        /// <summary>
        /// Set specific keywords to search within the listing description to narrow down query
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <example>Keywords(new string[] { "bungalow", "'double garage'" })</example>
        IPropertyOptions Keywords(params string[] value);

        /// <summary>
        /// Specify a specific agencies branch to request listings for
        /// </summary>
        /// <param name="branchId">Zoopla Branch Id</param>
        /// <returns></returns>
        IPropertyOptions SpecificBranch(int branchId);

        /// <summary>
        /// Specifying this will return a cut-down entry for each listing with a short description and the 
        /// following removed - price change, floor plan.
        /// </summary>
        IPropertyOptions Summary { get; }

        /// <summary>
        /// Specify the size of each page of results upto a maximum 100 (default 10).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IPropertyOptions PageSize(int value);
    }

    /// <summary>
    /// Represents the available methods to initiate the search
    /// </summary>
    public interface IPropertyActions : IFluent
    {
        /// <summary>
        /// Get a count of the listings for the specified query
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Get the listings for the specified query
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        IList<ZooplaListing> Go(int page = 1);
    }
}
