using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

//http://stackoverflow.com/questions/4367723/get-enum-from-description-attribute
namespace Zoopla.Fluent.Api.Extensions
{
    /// <exclude/>
    public static class EnumHelpers
    {
        /// <exclude/>
        public static string Val(this Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <exclude/>
        public static T EnumFromDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                .SelectMany(f => f.GetCustomAttributes(
                    typeof(DescriptionAttribute), false), (
                        f, a) => new { Field = f, Att = a })
                .Where(a => ((DescriptionAttribute)a.Att)
                    .Description == description).SingleOrDefault();
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }
    }
}
