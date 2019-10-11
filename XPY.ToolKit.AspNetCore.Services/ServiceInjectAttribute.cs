using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.AspNetCore.Services
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ServiceInjectAttribute : Attribute
    {
        public ServiceLifetime LifeTime { get; private set; }
        public Type ServiceType { get; set; }
        public ServiceInjectAttribute(ServiceLifetime lifetime)
        {
            LifeTime = lifetime;
        }
    }
}
