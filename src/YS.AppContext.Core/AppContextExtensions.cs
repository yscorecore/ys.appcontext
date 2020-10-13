using System;
using System.Globalization;

namespace YS.AppContext
{
    public static class AppContextExtensions
    {
        public static T GetValue<T>(this IAppContext context, string key)
        {
            var val = context?.GetValue(key);
            if (val is null)
            {
                return default;
            }
            if (val is T val1)
            {
                return val1;
            }
            return (T)Convert.ChangeType(val, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}
