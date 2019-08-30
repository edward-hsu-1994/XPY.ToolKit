using System;
using System.Collections.Generic;
using System.Linq;

namespace XPY.ToolKit.Linq {
    /// <summary>
    /// IEnumerable擴充方法
    /// </summary>
    public static class IEnumerableExtension {
        /// <summary>
        /// 切割列舉項目為指定長度
        /// </summary>
        /// <typeparam name="T">列舉元素類型</typeparam>
        /// <param name="obj">列舉實例</param>
        /// <param name="chunkSize">區段長度</param>
        /// <returns>切割後的列舉項目</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> obj, int chunkSize) {
            return Enumerable.Range(0, (int)Math.Ceiling(((double)obj.Count()) / chunkSize))
                .Select(x => obj.Skip(x * chunkSize).Take(chunkSize));
        }
    }
}
