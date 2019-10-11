using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace XPY.ToolKit.AspNetCore.Services
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());

            foreach (var type in allTypes)
            {
                var attr = type.GetCustomAttribute<ServiceInjectAttribute>();
                if (attr == null) continue;

                services.Add(new ServiceDescriptor(attr.ServiceType ?? type, type, attr.LifeTime));
            }
        }
    }
}
