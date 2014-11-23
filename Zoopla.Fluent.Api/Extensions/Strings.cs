using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Zoopla.Fluent.Api.Extensions
{
    /// <exclude/>
    public static class Strings
    {
        /// <exclude/>
        public static string ToQueryString(this NameValueCollection nvc)
        {
            return Append(nvc, '?');
        }

        /// <exclude/>
        public static string AppendQueryString(this NameValueCollection nvc)
        {
            return Append(nvc, '&');
        }

        /// <exclude/>
        private static string Append(this NameValueCollection nvc, char seperator)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}",
                         HttpUtility.UrlEncode(key),
                         HttpUtility.UrlEncode(value))).ToArray();
            return seperator + string.Join("&", array);
        }
    }
}
