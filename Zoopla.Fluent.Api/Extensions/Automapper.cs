using AutoMapper;
using System;
using System.Linq;
using Zoopla.Fluent.Api.Model;

// Usage: Mapper.CreateMap<string, System.Uri>().ConvertUsing<StringToUriConverter>();
namespace Zoopla.Fluent.Api.Extensions
{
    /// <exclude/>
    public class StringToUriConverter : ITypeConverter<string, System.Uri>
    {
        /// <exclude/>
        Uri ITypeConverter<string, Uri>.Convert(ResolutionContext context)
        {
            if (string.IsNullOrEmpty(context.SourceValue as string))
                return null;
            return new Uri((string)context.SourceValue);
        }
    }
}
