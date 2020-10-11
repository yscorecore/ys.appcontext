using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace YS.AppContext.Impl.Default
{
    [YS.Knife.Service(Lifetime = ServiceLifetime.Scoped)]
    public class DefaultAppContext : IAppContext
    {
        private static object locker = new object();
        private readonly AppContextOptions options;
        private readonly IServiceProvider serviceProvider;
        private Dictionary<string, object> cachedValues = new Dictionary<string, object>();

        public DefaultAppContext(IServiceProvider serviceProvider, AppContextOptions options)
        {
            this.serviceProvider = serviceProvider;
            this.options = options;
        }

        public object GetValue(string key)
        {
            lock (locker)
            {
                if (cachedValues.TryGetValue(key, out var storedValue))
                {
                    return storedValue;
                }

                if (options.Values.TryGetValue(key, out var factory))
                {
                    return cachedValues[key] = factory(serviceProvider, this);
                }

                return null;
            }
        }
    }
}
