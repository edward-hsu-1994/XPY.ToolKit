using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Linq.Paging {
    /// <summary>
    /// IEnumerable擴充方法
    /// </summary>
    public static class IEnumerableExtension {
        /// <summary>
        /// 將列舉項目轉換為分頁類型
        /// </summary>
        /// <typeparam name="TSource">元素類型</typeparam>
        /// <param name="source">分頁資料來源</param>
        /// <param name="offset">起始索引</param>
        /// <param name="limit">取得筆數</param>
        /// <returns>分頁結果</returns>
        public static CommonPagingResult<TSource> AsPaging<TSource>(
            this IEnumerable<TSource> source,
            int offset = 0,
            int limit = 10) {
            return new CommonPagingResult<TSource>(source, offset, limit);
        }
    }
}
