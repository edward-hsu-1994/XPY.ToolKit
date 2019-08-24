using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Utilities.Common {
    /// <summary>
    /// 時間轉換擴充方法
    /// </summary>
    public static partial class DateTimeExtension {
        /// <summary>
        /// 將目標<see cref="DateTime"/>實例轉換為Unix Timestamp
        /// </summary>
        /// <param name="datetime"><see cref="DateTime"/>實例</param>
        /// <returns><see cref="DateTime"/>實例之Unix Timestamp值</returns>
        public static long ToUnixTimestamp(this DateTime datetime) {
            return DateTimeUtility.ToUnixTimestamp(datetime);
        }

        /// <summary>
        /// 將目標<see cref="DateTime"/>實例轉換為Unix Timestamp Milliseconds
        /// </summary>
        /// <param name="datetime"><see cref="DateTime"/>實例</param>
        /// <returns><see cref="DateTime"/>實例之Unix Timestamp Milliseconds值</returns>
        public static long ToUnixTimestampMilliseconds(this DateTime datetime) {
            return DateTimeUtility.ToUnixTimestampMilliseconds(datetime);
        }
    }
}
