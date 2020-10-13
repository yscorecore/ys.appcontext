using System.Linq;
using Microsoft.AspNetCore.Http;

namespace YS.AppContext.AspnetCore.Common
{
    public class RequestIpContextValue : IAppContextValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestIpContextValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ContextKey { get => AppContextKeys.RequestIp; }

        public object GetContextValue(IAppContext context)
        {
            var ip = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }
    }
}
