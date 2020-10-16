using System.Linq;
using Microsoft.AspNetCore.Http;

namespace YS.AppContext.Values.AspnetCore.Common
{
    [AppContextValue]
    public class LogicRoleIdsContextValue : IAppContextValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogicRoleIdsContextValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string ContextKey { get => AppContextKeys.LogicRoleIds; }
        public object GetContextValue(IAppContext context)
        {
            return _httpContextAccessor.HttpContext?.User?.FindAll("LogicRoleId").Select(p=>p.Value).Distinct().ToList();
        }
    }
}
