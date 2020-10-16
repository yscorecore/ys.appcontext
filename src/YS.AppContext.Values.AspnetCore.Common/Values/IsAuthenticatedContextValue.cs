using Microsoft.AspNetCore.Http;

namespace YS.AppContext.Values.AspnetCore.Common
{
    [AppContextValue]
    public class IsAuthenticatedContextValue : IAppContextValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsAuthenticatedContextValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ContextKey => AppContextKeys.IsAuthenticated;

        public object GetContextValue(IAppContext context)
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}
