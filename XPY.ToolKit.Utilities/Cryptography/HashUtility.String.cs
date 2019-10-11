using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using XPY.ToolKit.Utilities.Common;

namespace XPY.ToolKit.Utilities.Cryptography
{
    /// <summary>
    /// 雜湊計算公用方法
    /// </summary>
    public static partial class HashUtility
    {
        /// <summary>
        /// 將字串使用指定的雜湊演算法轉換為雜湊
        /// </summary>
        /// <typeparam name="Algorithm">雜湊演算法型別</typeparam>
        /// <param name="str">值</param>
        /// <returns>雜湊Binary</returns>
        public static byte[] ToHash<Algorithm>(string str) where Algorithm : HashAlgorithm
        {
            using (var hash = typeof(Algorithm)
                .GetMethod("Create", new Type[] { })
                .Invoke(null, null) as HashAlgorithm)
            {
                return hash.ComputeHash(Encoding.UTF8.GetBytes(str));
            }
        }

        /// <summary>
        /// 將字串使用指定的雜湊演算法轉換為雜湊後在轉換為16進位字串表示
        /// </summary>
        /// <typeparam name="Algorithm">雜湊演算法型別</typeparam>
        /// <param name="str">值</param>
        /// <param name="upper">是否轉換為大寫</param>
        /// <returns>雜湊字串</returns>
        public static string ToHashString<Algorithm>(string str, bool upper = true) where Algorithm : HashAlgorithm
        {
            return string.Join("", BytesUtility.ToHex(ToHash<Algorithm>(str), upper));
        }
    }
}
