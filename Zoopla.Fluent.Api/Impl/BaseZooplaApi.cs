using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Zoopla.Fluent.Api.Extensions;

namespace Zoopla.Fluent.Api.Impl
{
    /// <exclude/>
    public abstract class BaseZooplaApi
    {
        /// <exclude/>
        private const string API_SERVER = "http://api.zoopla.co.uk";
        /// <exclude/>
        private const string API_LISTINGS_METHODS = "/api/v1/property_listings.json?api_key={0}";
        /// <exclude/>
        private const string API_AUTOCOMPLETE_METHODS = "/api/v1/geo_autocomplete.json?api_key={0}&search_term={1}&search_type={2}";
        /// <Exclude/>
        private const string HTML_IMG_REGEX = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
        /// <exclude/>
        private string ApiKey { get; set; }
        /// <exclude/>
        protected NameValueCollection Parameters = new NameValueCollection();

        /// <exclude/>
        protected BaseZooplaApi(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <exclude/>
        internal void SetParameter(string name, string value, OptionType options)
        {
            switch (options)
            {
                case OptionType.Once:
                    if (Parameters.AllKeys.Contains(name))
                        throw new OperationCanceledException(string.Format("Unable to add key twice [{0}]", name));
                    Parameters.Add(name, value);
                    break;
                case OptionType.Multple:
                    if (Parameters.GetValues(name).Contains(value))
                        throw new OperationCanceledException(string.Format("Unable to add key twice that have same value [{0}]", name));
                    Parameters.Add(name, value);
                    break;
                case OptionType.Overridable:
                    if (Parameters.AllKeys.Contains(name))
                        Parameters[name] = value;
                    else
                        Parameters.Add(name, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <exclude/>
        internal RootGeoAutocomplete LocationResults(string searchTerm, string searchType)
        {
            var path = string.Format(
                API_AUTOCOMPLETE_METHODS,
                ApiKey,
                searchTerm,
                searchType
                );

            return JsonConvert.DeserializeObject<RootGeoAutocomplete>(new GZipWebClient().DownloadString(API_SERVER + path));
        }

        /// <exclude/>
        internal RootPropertyListings PropertyResults()
        {
            var path = string.Format(API_LISTINGS_METHODS,ApiKey);
            if (Parameters.Count > 0)
                path = path + Parameters.AppendQueryString();

            return JsonConvert.DeserializeObject<RootPropertyListings>(new GZipWebClient().DownloadString(API_SERVER + path));
        }

        /// <exclude/>
        protected IList<Uri> GetImageLinksFromUrl(Uri uri)
        {
            return ImageLinksFromHtmlSource(new GZipWebClient().DownloadString(uri)).ToList();
        }

        /// <exclude/>
        /// <remarks>
        /// Images on page are - 80_60, 150_113, 645_430
        /// </remarks>
        private IList<Uri> ImageLinksFromHtmlSource(string htmlSource)
        {
            List<Uri> links = new List<Uri>();

            MatchCollection matches = Regex.Matches(htmlSource, HTML_IMG_REGEX, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match m in matches)
            {
                string href = m.Groups[1].Value.ToLower();

                if (href.StartsWith("http") && href.Contains("li.zoocdn.com") && href.Contains("_80_60"))
                {
                    links.Add(new Uri(href.Replace("li.", "lc.").Replace("_80_60", "")));
                }
            }

            return links;
        }
    }
}
