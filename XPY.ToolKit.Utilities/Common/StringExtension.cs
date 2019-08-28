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

        /// <summary>
        /// 安全的從目前實例擷取子字串。子字串會在指定的字元開始並繼續到字串結尾
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <param name="startIndex">起始索引</param>
        /// <param name="length">擷取子字串最長長度</param>
        /// <returns>子字串</returns>
        public static string SafeSubstring(this string str, int startIndex, int? length = null) {
            return StringUtility.SafeSubstring(str, startIndex, length);
        }

        /// <summary>
        /// 檢查字串是否符合表示式
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <param name="pattern">正規表示式</param>
        /// <returns>是否符合表示式</returns>
        public static bool IsMatch(this string str, string pattern) {
            return StringUtility.IsMatch(str, pattern);
        }

        /// <summary>
        /// 取得指定字串間的字串
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <param name="start">起始字串</param>
        /// <param name="end">結束字串</param>
        /// <returns>字串間的字串</returns>
        public static string InnerString(this string str, string start, string end) {
            return StringUtility.InnerString(str, start, end);
        }
    }
}
