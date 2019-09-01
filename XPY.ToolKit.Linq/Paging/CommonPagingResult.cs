using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPY.ToolKit.Linq.Paging {
    /// <summary>
    /// 通用分頁結果
    /// </summary>
    /// <typeparam name="TSource">列舉成員類型</typeparam>
    public class CommonPagingResult<TSource> : IPagingResult<TSource> {
        /// <summary>
        /// 分頁資料來源
        /// </summary>
        public virtual IEnumerable<TSource> Source { get; private set; }

        /// <summary>
        /// 分頁結果
        /// </summary>
        public virtual IEnumerable<TSource> Result {
            get {
                IEnumerable<TSource> result = null;
                if (Offset == -1) {
                    result = Source.Skip(Offset);
                } else {
                    result = Source.Skip(Offset).Take(Limit).ToArray();
                }

                return result;
            }
        }

        /// <summary>
        /// 起始索引
        /// </summary>
        public virtual int Offset { get; private set; }

        /// <summary>
        /// 取得筆數
        /// </summary>
        public virtual int Limit { get; private set; }

        /// <summary>
        /// 資料總數
        /// </summary>
        public virtual int TotalCount => Source.Count();

        /// <summary>
        /// 目前所在分頁索引
        /// </summary>
        public virtual int CurrentPageIndex {
            get {
                if (Offset == -1) return 0;
                return (int)Math.Floor(Offset / (double)Limit);
            }
        }

        /// <summary>
        /// 總頁數
        /// </summary>
        public virtual int TotalPageCount {
            get {
                if (Offset == -1) return 1;
                return (int)Math.Ceiling(TotalCount / (double)Limit);
            }
        }

        /// <summary>
        /// 是否有上一頁
        /// </summary>
        public virtual bool HasPreviousPage => CurrentPageIndex > 0;

        /// <summary>
        /// 是否有下一頁
        /// </summary>
        public virtual bool HasNextPage => CurrentPageIndex < TotalPageCount - 1;

        /// <summary>
        /// 通用分頁結果預設建構子
        /// </summary>
        [Obsolete("此建構子僅供Proxy使用", true)]
        public CommonPagingResult() { }

        /// <summary>
        /// 通用分頁結果建構子
        /// </summary>
        /// <param name="source">分頁資料來源</param>
        /// <param name="offset">起始索引</param>
        /// <param name="limit">取得筆數，如果為-1則表示取得所有資訊不分頁</param>
        public CommonPagingResult(IEnumerable<TSource> source, int offset, int limit) {
            this.Source = source;
            this.Offset = offset;
            this.Limit = limit;
        }

        /// <summary>
        /// 移動目前所在分頁索引至指定索引
        /// </summary>
        /// <param name="pageIndex">頁數索引</param>
        /// <returns></returns>
        public virtual bool MoveToPage(int pageIndex) {
            if (Offset == -1 && pageIndex != 0) {
                return false;
            }

            var newOffset = Offset * pageIndex;

            if (newOffset < 0 || newOffset >= TotalCount) return false;

            Offset = newOffset;

            return true;
        }

        /// <summary>
        /// 取得指定分頁索引的分頁物件，如無下個分頁則返回<see cref="null"/>
        /// </summary>
        /// <param name="pageIndex">頁數索引</param>
        /// <returns>分頁物件</returns>
        public virtual CommonPagingResult<TSource> GetMoveToPage(int pageIndex) {
            if (Offset == -1 && pageIndex != 0) {
                pageIndex = 0;
            }

            var newOffset = Offset * pageIndex;

            if (newOffset < 0 || newOffset >= TotalCount) return null;

            return new CommonPagingResult<TSource>(Source, newOffset, Limit);
        }

        /// <summary>
        /// 前後頁移動目前所在分頁索引
        /// </summary>
        /// <param name="deltaPageCount">分頁索引變動量</param>
        /// <returns>是否移動成功</returns>
        public virtual bool MovePage(int deltaPageCount) {
            if (Limit == -1 && deltaPageCount != 0) {
                return false;
            }

            var newOffset = Offset + Limit * deltaPageCount;

            if (newOffset < 0 || newOffset >= TotalCount) return false;

            Offset = newOffset;

            return true;
        }

        /// <summary>
        /// 取得前後頁移動目前所在分頁索引後的新的分頁物件，如無下個分頁則返回<see cref="null"/>
        /// </summary>
        /// <param name="deltaPageCount">分頁索引變動量</param>
        /// <returns>分頁物件</returns>
        public virtual CommonPagingResult<TSource> GetMovePage(int deltaPageCount) {
            if (Offset == -1 && deltaPageCount != 0) {
                return null;
            }

            var newOffset = Offset + Limit * deltaPageCount;

            if (newOffset < 0 || newOffset >= TotalCount) return null;

            return new CommonPagingResult<TSource>(Source, newOffset, Limit);
        }

        /// <summary>
        /// 重設目前分頁索引為0
        /// </summary>
        public virtual void Reset() {
            MoveToPage(0);
        }
    }
}
