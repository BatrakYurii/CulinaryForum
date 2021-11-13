using System;
using System.ComponentModel;
using System.Reflection;

namespace Forum.Api.Auth.Models
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            return fi.GetCustomAttribute<DescriptionAttribute>().Description;
        }
    }    
}
