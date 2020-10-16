using Microsoft.AspNetCore.Http;

namespace YS.AppContext.AspnetCore.Common
{
    [AppContextValue]
    public class IsAuthenticatedContextValue : IAppContextValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string ContextKey => AppContextKeys.IsAuthenticated;

        public object GetContextValue(IAppContext context)
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}
