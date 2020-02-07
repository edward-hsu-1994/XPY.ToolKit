using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPY.ToolKit.AspNetCore.DependencyInjection
{
    /// <summary>
    /// 循環DI修正擴充類別
    /// </summary>
    public static class CycleDependencyInjectionExtensions
    {
        /// <summary>
        /// 修復循環參照DI
        /// </summary>
        /// <param name="serviceCollection">服務容器</param>
        /// <returns>服務容器</returns>
        public static IServiceCollection FixCycleDI(this IServiceCollection serviceCollection)
        {
            foreach (var sd in serviceCollection.ToList())
            {
                var cycleType = typeof(Cycle<>).MakeGenericType(sd.ServiceType);

                Func<IServiceProvider, object> factory = (sp) => {
                    return cycleType
                        .GetConstructor(new Type[] { typeof(IServiceProvider) })
                        .Invoke(new object[] { sp });
                };

                var cycleSD = new ServiceDescriptor(cycleType, factory, sd.Lifetime);

                serviceCollection.Add(cycleSD);
            }

            return serviceCollection;
        }
    }
}
