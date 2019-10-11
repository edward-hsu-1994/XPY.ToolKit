using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Utilities.Common
{
    public static partial class DateTimeExtension
    {
        /// <summary>
        /// 將Unix Timestamp轉換為<see cref="DateTime"/>實例
        /// </summary>
        /// <param name="unixTime">Unix Timestamp</param>
        /// <returns><see cref="DateTime"/>實例結果</returns>
        public static DateTime ToDateTimeFromTimestamp(this long unixTime)
        {
            return DateTimeUtility.FromUnixTimestamp(unixTime);
        }

        /// <summary>
        /// 將Unix Timestamp Milliseconds轉換為<see cref="DateTime"/>實例
        /// </summary>
        /// <param name="unixTime">Unix Timestamp Milliseconds</param>
        /// <returns><see cref="DateTime"/>實例結果</returns>
        public static DateTime ToDateTimeFromTimestampMilliseconds(this long unixTime)
        {
            return DateTimeUtility.FromUnixTimestampMilliseconds(unixTime);

        }
    }
}
