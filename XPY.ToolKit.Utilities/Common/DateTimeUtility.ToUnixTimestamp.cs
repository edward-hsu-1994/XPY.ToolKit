using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Utilities.Common
{
    /// <summary>
    /// 時間轉換公用方法
    /// </summary>
    public static partial class DateTimeUtility
    {
        /// <summary>
        /// 取得現在Unix Timestamp
        /// </summary>
        /// <returns>Unix Timestamp值</returns>
        public static long GetNowUnixTimestamp() => ToUnixTimestamp(DateTime.Now);

        /// <summary>
        /// 取得現在Unix Timestamp Milliseconds
        /// </summary>
        /// <returns>Unix Timestamp Milliseconds值</returns>
        public static long GetNowUnixTimestampMilliseconds() => ToUnixTimestampMilliseconds(DateTime.Now);

        /// <summary>
        /// 將目標<see cref="DateTime"/>實例轉換為Unix Timestamp
        /// </summary>
        /// <param name="datetime"><see cref="DateTime"/>實例</param>
        /// <returns><see cref="DateTime"/>實例之Unix Timestamp值</returns>
        public static long ToUnixTimestamp(DateTime datetime)
        {
            return (long)(datetime.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))
                    .TotalMilliseconds / 1000;
        }

        /// <summary>
        /// 將目標<see cref="DateTime"/>實例轉換為Unix Timestamp Milliseconds
        /// </summary>
        /// <param name="datetime"><see cref="DateTime"/>實例</param>
        /// <returns><see cref="DateTime"/>實例之Unix Timestamp Milliseconds值</returns>
        public static long ToUnixTimestampMilliseconds(DateTime datetime)
        {
            return (long)(datetime.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))
                    .TotalMilliseconds;
        }
    }
}
