using System;
using System.Collections.Generic;

namespace PrisonArchitect
{
    public static class ObjectExtension
    {
        public static bool HasProperty(this object obj, string propertyName)
        {
            var type = obj.GetType();
            var prop = type.GetProperty(propertyName);
            return prop != null;
        }

        public static void SetProperty(this object obj, string propertyName, object value)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new Exception("Unknown Property: " + propertyName);
            }
            var val = System.Convert.ChangeType(value, property.PropertyType);
            property.SetValue(obj, val, null);
        }
    }

    public static class StringExtensions
    {

        public static string UcFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}