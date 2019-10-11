using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Utilities.Common
{
    public static partial class DateTimeUtility
    {
        /// <summary>
        /// 將Unix Timestamp轉換為<see cref="DateTime"/>實例
        /// </summary>
        /// <param name="unixTime">Unix Timestamp</param>
        /// <returns><see cref="DateTime"/>實例結果</returns>
        public static DateTime FromUnixTimestamp(long unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddMilliseconds(unixTime * 1000);
        }

        /// <summary>
        /// 將Unix Timestamp Milliseconds轉換為<see cref="DateTime"/>實例
        /// </summary>
        /// <param name="unixTime">Unix Timestamp Milliseconds</param>
        /// <returns><see cref="DateTime"/>實例結果</returns>
        public static DateTime FromUnixTimestampMilliseconds(long unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddMilliseconds(unixTime);
        }
    }
}
