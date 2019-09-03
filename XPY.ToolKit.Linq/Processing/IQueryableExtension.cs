using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPY.ToolKit.Linq.Processing {
    /// <summary>
    /// IQueryable擴充方法
    /// </summary>
    public static class IQueryableExtension {
        /// <summary>
        /// 查詢結果處理或轉換
        /// </summary>
        /// <typeparam name="TSource">來源類型</typeparam>
        /// <typeparam name="TResult">結果類型</typeparam>
        /// <param name="queryEnum">來源集合</param>
        /// <param name="process">處理或轉換方法</param>
        /// <returns>轉換結果集合</returns>
        public static IEnumerable<TResult> Process<TSource, TResult>(
            this IQueryable<TSource> queryEnum,
            Func<TSource, TResult> process) {
            return new ProcessedQueryable<TSource, TResult>() {
                Source = queryEnum,
                Process = process
            };
        }
    }
}
