using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Service.ExtensionMethods
{
    public static class DateExtension
    {
        public static string ToCrazyPattelsPattern(this DateTime value)
        {
            return value.ToString("dd-MM-yyyy");
        }

    }
}
