using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Linq.Paging {
    /// <summary>
    /// 分頁結果
    /// </summary>
    /// <typeparam name="TSource">列舉成員類型</typeparam>
    public interface IPagingResult<TSource> {
        /// <summary>
        /// 起始索引
        /// </summary>
        int Offset { get; }

        /// <summary>
        /// 取得筆數
        /// </summary>
        int Limit { get; }

        /// <summary>
        /// 資料總數
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// 目前頁數索引
        /// </summary>
        int CurrentPageIndex { get; }

        /// <summary>
        /// 總頁數數量
        /// </summary>
        int TotalPageCount { get; }

        /// <summary>
        /// 是否有上一頁
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// 是否有下一頁
        /// </summary>
        bool HasNextPage { get; }
    }
}
