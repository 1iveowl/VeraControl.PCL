using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraControl.Extensions
{
    internal static class HelperExtensions
    {
        internal static DateTime UnixTimestampToUtcDateTime(this int unixTimestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimestamp).ToUniversalTime();

            return dateTime;
        }
    }
}
