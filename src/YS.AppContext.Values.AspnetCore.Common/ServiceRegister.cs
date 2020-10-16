using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using YS.Knife;

namespace YS.AppContext.Values.AspnetCore.Common
{
    public class ServiceRegister :IServiceRegister
    {
        public void RegisterServices(IServiceCollection services, IRegisteContext context)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
