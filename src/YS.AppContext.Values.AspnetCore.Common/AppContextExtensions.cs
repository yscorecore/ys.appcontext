using System.Collections.Generic;

namespace YS.AppContext
{
    public static class AppContextExtensions
    {
        public static string UserId(this IAppContext appContext)
        {
            return appContext.GetValue<string>(nameof(AppContextKeys.UserId));
        }
        public static string UserName(this IAppContext appContext)
        {
            return appContext.GetValue<string>(nameof(AppContextKeys.UserName));
        }
        public static bool IsAuthenticated(this IAppContext appContext)
        {
            return appContext.GetValue<bool>(nameof(AppContextKeys.IsAuthenticated));
        }
        public static IList<string> LogicRoleIds(this IAppContext appContext)
        {
            return appContext.GetValue<IList<string>>(nameof(AppContextKeys.LogicRoleIds));
        }
        public static string RequestIp(this IAppContext appContext)
        {
            return appContext.GetValue<string>(nameof(AppContextKeys.RequestIp));
        }
    }
}
