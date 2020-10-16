using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace YS.AppContext
{
    [YS.Knife.Service(Lifetime = ServiceLifetime.Scoped)]
    public class DefaultAppContext : IAppContext
    {
        private readonly Dictionary<string, object> _cachedValues = new Dictionary<string, object>();
        private readonly IDictionary<string, IAppContextValue> _appContextValues;

        public DefaultAppContext(IEnumerable<IAppContextValue> appContextValues)
        {
            _ = appContextValues ?? throw new ArgumentNullException(nameof(appContextValues));
            _appContextValues = appContextValues.Where(p=>!string.IsNullOrEmpty(p?.ContextKey))
                .ToDictionary(p => p.ContextKey);
        }

        public object GetValue(string key)
        {
            lock (this)
            {
                if (_cachedValues.TryGetValue(key, out var storedValue))
                {
                    return storedValue;
                }
                if (_appContextValues.TryGetValue(key, out var valueFactory))
                {
                    return _cachedValues[key] = valueFactory.GetContextValue(this);
                }
                throw new ApplicationException($"The key '{key}' not found in current app context.");
            }
            
        }
    }
}
