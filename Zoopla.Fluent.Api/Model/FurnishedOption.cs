using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Zoopla.Fluent.Api.Model
{
    /// <summary>
    /// Furnishing options
    /// </summary>
    public enum FurnishedOption
    {
        /// <summary>
        /// Furnished
        /// </summary>
        [Description("furnished")]
        Furnished,
        /// <summary>
        /// Un-furnished
        /// </summary>
        [Description("unfurnished")]
        Unfurnished,
        /// <summary>
        /// Part-furnished
        /// </summary>
        [Description("part-furnished")]
        PartFurnished,
    }
}
