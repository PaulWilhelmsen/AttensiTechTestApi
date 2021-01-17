using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Common.Extensions
{
    public static class IntExtension
    {
        public static string FromMinutesToHours(this int minutes)
        {
            var time = TimeSpan.FromMinutes(minutes);
            var paddedHours = time.Hours.ToString().PadLeft(2, '0');
            var paddedMinutes = time.Minutes.ToString().PadLeft(2, '0');
            
            return $"{paddedHours}:{paddedMinutes}";
        }
    }
}
