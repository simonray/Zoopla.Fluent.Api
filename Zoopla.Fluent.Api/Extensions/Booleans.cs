using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoopla.Fluent.Api.Extensions
{
    /// <exclude/>
    public static class Booleans
    {
        /// <exclude/>
        public static string ToYesNoString(this bool value)
        {
            return value ? "yes" : "no";
        }
    }
}
