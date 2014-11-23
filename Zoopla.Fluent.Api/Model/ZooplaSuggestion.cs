using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoopla.Fluent.Api.Model
{
    /// <summary>
    /// Represents a suggestion for a geo autocomplete query
    /// </summary>
    [DebuggerDisplay("{Id} - {Name}")]
    public class ZooplaSuggestion
    {
        /// <summary>
        /// An area identifier for the suggestion
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Suggestion for autocompletion
        /// </summary>
        public string Name { get; set; }
    }
}
