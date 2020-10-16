using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace YS.AppContext.Values.AspnetCore.Common
{
    [AppContextValue]
    public class UserNameContextValue:IAppContextValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserNameContextValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string ContextKey { get => AppContextKeys.UserName; }
        public object GetContextValue(IAppContext context)
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        }
    }
}
