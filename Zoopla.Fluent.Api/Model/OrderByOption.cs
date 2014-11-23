using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Zoopla.Fluent.Api.Model
{
    /// <summary>
    /// Ordering options
    /// </summary>
    public enum OrderByOption
    {
        /// <summary>
        /// By price
        /// </summary>
        [Description("price")]
        Price,
        /// <summary>
        /// By listing age
        /// </summary>
        [Description("age")]
        Age,
    }
}
