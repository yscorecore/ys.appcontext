using System;
using System.Globalization;

namespace YS.AppContext
{
    public static class AppContextExtensions
    {
        public static T GetValue<T>(this IAppContext context, string key)
        {
            var val = context?.GetValue(key);
            return val == null ? default : (T)Convert.ChangeType(val, typeof(T), CultureInfo.InvariantCulture);
        }
        public static string UserName(this IAppContext context)
        {
            return context.GetValue<string>(AppContextKeys.UserName);
        }
        public static string RequestIp(this IAppContext context)
        {
            return context.GetValue<string>(AppContextKeys.RequestIp);
        }
        public static string RequestLanguage(this IAppContext context)
        {
            return context.GetValue<string>(AppContextKeys.RequestLanguage);
        }
    }
}
