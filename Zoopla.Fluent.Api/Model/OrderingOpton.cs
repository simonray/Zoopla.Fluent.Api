using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Zoopla.Fluent.Api.Model
{
    /// <summary>
    /// Ordering direction option
    /// </summary>
    public enum OrderingOption
    {
        /// <summary>
        /// Descending order
        /// </summary>
        [Description("descending")]
        Descending,
        /// <summary>
        /// Ascending order
        /// </summary>
        [Description("ascending")]
        Ascending,
    }
}
