using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace XPY.ToolKit.AspNetCore.DependencyInjection
{
    /// <summary>
    /// Services注入擴充類別
    /// </summary>
    public static class InjectCollectionExtensions
    {
        /// <summary>
        /// 使用InjectAttribute的方式加入服務容器項目
        /// </summary>
        /// <param name="collection">服務容器</param>
        /// <returns>服務容器</returns>
        public static IServiceCollection AddInject(this IServiceCollection collection)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetExportedTypes());

            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<InjectAttribute>();
                if (attr == null) continue;

                collection.Add(new ServiceDescriptor(attr.ServiceType ?? type, type, attr.LifeTime));
            }

            return collection;
        }
    }
}
