using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoopla.Fluent.Api.Model;

namespace Zoopla.Fluent.Api
{
    /// <summary>
    /// Required to hide the implementation of the .NET base classes to make a nicer fluent interface for context help
    /// NOTE: Can only be seen in seperate VS instance, same VS instance still appear
    /// </summary>
    /// <exclude/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFluent
    {
        /// <exclude/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        /// <exclude/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        /// <exclude/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        /// <exclude/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
    }
}
