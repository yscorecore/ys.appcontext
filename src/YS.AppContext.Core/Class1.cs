using System;
using System.Collections.Generic;
using System.IO;

namespace YS.AppContext
{
    public interface IAppContext
    {
        object GetValue(string key);
    }

    public static class IAppContextExtensions
    {
        public static T GetValue<T>(this IAppContext context, string key)
        {
            var val = context.GetValue(key);
            return val == null ? default : (T)Convert.ChangeType(val,typeof(T));
        }
    }


    public class MyContext
    {
        private readonly IAppContext _context;

        public string UserId
        {
            get => _context.GetValue<string>(nameof(UserId));
        }

      
    }

    

    public class CommonContextValues
    {
        public static string GetUserId(IServiceProvider serviceProvider, AppContextOptions options)
        {
            return "mockUserId";
        }

        public static string GetRoleId(IServiceProvider serviceProvider)
        {
            return "";
        }
    }
    
    public class AppContextOptions
    {
        public Dictionary<String, List<string>> Aliases { get; set; }

        public IDictionary<string, Func<IServiceProvider, IAppContext, object>> Values { get; } =
            new Dictionary<string, Func<IServiceProvider, IAppContext, object>>();
    }
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
