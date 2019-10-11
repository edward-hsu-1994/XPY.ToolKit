using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace XPY.ToolKit.Utilities.Cryptography
{
    /// <summary>
    /// 雜湊計算擴充方法
    /// </summary>
    public static partial class HashExtension
    {
        /// <summary>
        /// 將字串使用指定的雜湊演算法轉換為雜湊
        /// </summary>
        /// <typeparam name="Algorithm">雜湊演算法型別</typeparam>
        /// <param name="str">字串</param>
        /// <returns>雜湊Binary</returns>
        public static byte[] ToHash<Algorithm>(this string str) where Algorithm : HashAlgorithm
        {
            return HashUtility.ToHash<Algorithm>(str);
        }

        /// <summary>
        /// 將字串使用指定的雜湊演算法轉換為雜湊後在轉換為16進位字串表示
        /// </summary>
        /// <typeparam name="Algorithm">雜湊演算法型別</typeparam>
        /// <param name="str">字串</param>
        /// <param name="upper">是否轉換為大寫</param>
        /// <returns>雜湊字串</returns>
        public static string ToHashString<Algorithm>(this string str, bool upper = true) where Algorithm : HashAlgorithm
        {
            return HashUtility.ToHashString<Algorithm>(str, upper);
        }
    }
}
