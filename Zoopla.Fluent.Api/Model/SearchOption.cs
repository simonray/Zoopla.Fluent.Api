using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoopla.Fluent.Api.Model
{
    /// <summary>
    /// Search options for area suggestions
    /// </summary>
    public enum SearchOption
    {
        /// <summary>
        /// For sale or renatals 
        /// </summary>
        [Description("listings")]
        SaleOrRentals,
        /// <summary>
        /// Sold or current
        /// </summary>
        [Description("properties")]
        SoldOrValues,
    }
}
