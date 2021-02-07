using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inalambria.WebApi.Util
{
    public static class CustomDateTime
    {
        /// <summary>
        /// Convert string to datetime
        /// </summary>
        /// <param name="dateString">the string datetime to convert. The string datetime format is defined in GlobalProperties.DateFormatFilter</param>
        /// <param name="dateRange">Datetime range false:until, true:since</param>
        /// <returns>Datetime. If convertion is not posible returns null</returns>
        public static DateTime? Parse(string dateString, bool? dateRange = null)
        {
            string dateFormat = GlobalProperties.DateFormatFilter;

            if (!string.IsNullOrEmpty(dateString))
            {
                if (DateTime.TryParseExact(dateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime outDate))
                    return outDate;
                // Try concatenate the time when only comes the date 
                if (dateRange.HasValue)
                {
                    if (dateRange.Value)
                        dateString = string.Concat(dateString, " 00:00:00");
                    else
                        dateString = string.Concat(dateString, " 23:59:59");
                    if (DateTime.TryParseExact(dateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out outDate))
                        return outDate;
                }
            }

            return null;
        }
        public static DateTime ConvertToUtc(DateTime dateTime, string timeZoneInfoId)
        {
            TimeZoneInfo targetTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfoId);
            return TimeZoneInfo.ConvertTime(dateTime, targetTimeZoneInfo, TimeZoneInfo.Utc);
        }
        public static DateTime ConvertFromUtc(DateTime dateTime, string timeZoneInfoId)
        {
            TimeZoneInfo targetTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfoId);
            return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc, targetTimeZoneInfo);
        }
    }
}
