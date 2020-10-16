using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YS.AppContext.Values.AspnetCore.Common.Values
{
    [AppContextValue]
    public class CorrelationIdContextValue : IAppContextValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CorrelationIdContextValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ContextKey { get => AppContextKeys.CorrelationId; }

        public object GetContextValue(IAppContext context)
        {
            var cid = _httpContextAccessor.HttpContext.Request.Headers["X-Correlation-ID"].FirstOrDefault();
            if (string.IsNullOrEmpty(cid))
            {
                cid = _httpContextAccessor.HttpContext.TraceIdentifier;
            }
            return cid;
        }
    }
}
