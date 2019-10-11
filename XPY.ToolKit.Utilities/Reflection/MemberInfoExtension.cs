using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace XPY.ToolKit.Utilities.Reflection
{
    /// <summary>
    /// MemberInfo擴充方法
    /// </summary>
    public static class MemberInfoExtension
    {
        static MemberInfo GetMember(Expression expression)
        {
            if (expression is MethodCallExpression)
            {
                return (expression as MethodCallExpression)?.Method;
            }
            else if (expression is MemberExpression)
            {
                return (expression as MemberExpression)?.Member;
            }
            else if (expression is NewExpression)
            {
                return (expression as NewExpression)?.Constructor;
            }
            else if (expression is UnaryExpression)
            {
                return GetMember((expression as UnaryExpression)?.Operand);
            }
            return null;
        }

        /// <summary>
        /// 取得指定成員資訊
        /// </summary>
        /// <typeparam name="T">目標實例類別</typeparam>
        /// <param name="instance">目標實例</param>
        /// <param name="expression">Lambda運算式(建構子、無回傳值方法)</param>
        /// <returns>成員資訊</returns>
        public static MemberInfo GetMemberInfo<T>(this T instance, Expression<Action<T>> expression)
        {
            return GetMember((Expression)expression.Body);
        }

        /// <summary>
        /// 取得指定成員資訊
        /// </summary>
        /// <typeparam name="T">目標實例類別</typeparam>
        /// <param name="instance">目標實例</param>
        /// <param name="expression">Lambda運算式(建構子、屬性、欄位、索引子、方法)</param>
        /// <returns>成員資訊</returns>
        public static MemberInfo GetMemberInfo<T>(this T instance, Expression<Func<T, object>> expression)
        {
            return GetMember((Expression)expression.Body);
        }
    }
}
