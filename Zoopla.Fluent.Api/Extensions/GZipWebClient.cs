using System;
using System.Net;

//http://stackoverflow.com/questions/4567313/uncompressing-gzip-response-from-webclient
namespace Zoopla.Fluent.Api.Extensions
{
    /// <exclude/>
    public class GZipWebClient : WebClient
    {
        /// <exclude/>
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Proxy = null;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return request;
        }
    }
}
