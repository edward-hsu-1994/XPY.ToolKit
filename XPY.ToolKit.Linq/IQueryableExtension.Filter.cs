using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace XPY.ToolKit.Linq {
    public static partial class IQueryableExtension {
        /// <summary>
        /// 針對指定屬性取得值相等的成員
        /// </summary>
        /// <typeparam name="TSource">列舉元素類型</typeparam>
        /// <typeparam name="TProperty">條件屬性類型</typeparam>
        /// <param name="source">列舉來源</param>
        /// <param name="selector">查詢屬性</param>
        /// <param name="value">值，如為空則表示不篩選</param>
        /// <returns>查詢結果</returns>
        public static IQueryable<TSource> Filter<TSource, TProperty>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TProperty>> selector,
            Nullable<TProperty> value)
            where TProperty : struct {
            var result = source;

            var p = Expression.Parameter(typeof(TSource), "x");

            if (value.HasValue) {
                return result.Where(
                        Expression.Lambda<Func<TSource, bool>>(
                            Expression.Equal(
                                Expression.Constant(value, typeof(Nullable<TProperty>)),
                                Expression.Constant(null, typeof(Nullable<TProperty>))
                            ), p)
                      );
            } else {
                return result;
            }
        }
    }
}
