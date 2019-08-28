using PCRE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace XPY.ToolKit.Utilities.Common {
    /// <summary>
    /// 常用String處理方法
    /// </summary>
    public static class StringUtility {
        /// <summary>
        /// 檢查字元是否在指定區間內
        /// </summary>
        /// <param name="char">字元</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>是否在區間內</returns>
        private static bool Between(this char @char, int min, int max) {
            return @char >= min && @char <= max;
        }

        /// <summary>
        /// Unicode CJK範圍
        /// </summary>
        private static Func<char, string>[] LangRanges = new Func<char, string>[] {
            (c)=> {//Unicode CJK範圍
                if(c.Between(0x2E80, 0x2EFF) ||
                   c.Between(0x3000, 0x303F) ||
                   c.Between(0x3200, 0x32FF) ||
                   c.Between(0x3300, 0x33FF) ||
                   c.Between(0x3400, 0x4DBF) ||
                   c.Between(0x4E00, 0x9FFF) ||
                   c.Between(0xF900, 0xFAFF) ||
                   c.Between(0xFE30, 0xFE4F) ||
                   c.Between(0x20000, 0x2A6DF) ||
                   c.Between(0x2F800, 0x2FA1F)) {
                    return "CJK";
                }
                return null;
            },
            (c)=> {
                return "other";
            }
        };

        /// <summary>
        /// 取得指定字元語系
        /// </summary>
        /// <param name="c">字元</param>
        /// <returns>語系名稱</returns>
        private static string GetLangType(this char c) {
            string result = null;
            foreach (var func in LangRanges) {
                result = func(c);
                if (result != null) break;
            }
            return result;
        }


        /// <summary>
        /// 字串中不同語系文字中插入空白字元
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <returns>自動加入空白後的字串</returns>
        public static string Spacing(string str) {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < str.Length - 1; i++) {
                builder.Append(str[i]);
                if (str[i] == ' ' || str[i + 1] == ' ') continue;
                if (str[i].GetLangType() != str[i + 1].GetLangType()) {
                    builder.Append(' ');
                }
            }

            builder.Append(str.Last());
            return builder.ToString();
        }

        /// <summary>
        /// 將字串根據指定區塊大小切割
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <param name="chunkSize">區塊大小</param>
        /// <returns>切割後的字串</returns>
        public static string[] Split(string str, int chunkSize) {
            return Enumerable.Range(0, (int)Math.Ceiling(((double)str.Length) / chunkSize))
                .Select(x => SafeSubstring(str, x * chunkSize, chunkSize))
                .ToArray();
        }

        /// <summary>
        /// 安全的從目前實例擷取子字串。子字串會在指定的字元開始並繼續到字串結尾
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <param name="startIndex">起始索引</param>
        /// <param name="length">擷取子字串最長長度</param>
        /// <returns>子字串</returns>
        public static string SafeSubstring(string str, int startIndex, int? length = null) {
            if (!length.HasValue) length = str.Length;
            if (str.Length <= startIndex) return string.Empty;
            if (startIndex < 0) startIndex = 0;
            if (length < 0) length = 0;
            string result = str.Substring(startIndex);
            length = Math.Min(result.Length, length.Value);
            return result.Substring(0, length.Value);
        }

        /// <summary>
        /// 檢查字串是否符合表示式
        /// </summary>
        /// <param name="str">字串實例</param>
        /// <param name="pattern">正規表示式</param>
        /// <returns>是否符合表示式</returns>
        public static bool IsMatch(string str, string pattern) {
            var regex = new PcreRegex(pattern);
            return regex.IsMatch(str);
        }
    }
}
