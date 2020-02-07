using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.AspNetCore.DependencyInjection
{
    public class Cycle<T>
    {
        private Lazy<T> _instance = null;

        public T Instance {
            get {
                return _instance.Value;
            }
        }

        public Cycle(T instance)
        {
            _instance = new Lazy<T>(() => {
                return instance;
            });
        }

        public Cycle(IServiceProvider serviceProvider)
        {
            _instance = new Lazy<T>(() => {
                return (T)serviceProvider.GetService(typeof(T));
            });
        }

        public static implicit operator T(Cycle<T> cycle)
        {
            return cycle.Instance;
        }
    }
}
