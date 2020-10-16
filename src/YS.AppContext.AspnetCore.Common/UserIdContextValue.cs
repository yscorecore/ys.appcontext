using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YS.AppContext.AspnetCore.Common
{
    public class UserIdContextValue : IAppContextValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserIdContextValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string ContextKey { get => AppContextKeys.UserId; }
        public object GetContextValue(IAppContext context)
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
