using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPY.ToolKit.Utilities.Common {
    /// <summary>
    /// 常用String處理擴充方法
    /// </summary>
    public static class StringExtension {
        /// <summary>
        /// 字串中不同語系文字中插入空白字元
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <returns>自動加入空白後的字串</returns>
        public static string Spacing(this string str) {
            return StringUtility.Spacing(str);
        }

        /// <summary>
        /// 將字串根據指定區塊大小切割
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <param name="chunkSize">區塊大小</param>
        /// <returns>切割後的字串</returns>
        public static string[] Split(this string str, int chunkSize) {
            return StringUtility.Split(str, chunkSize);
        }
    }
}
