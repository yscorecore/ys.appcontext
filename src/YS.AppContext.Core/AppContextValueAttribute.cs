using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using YS.Knife;

namespace YS.AppContext
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class AppContextValueAttribute : KnifeAttribute
    {
        public AppContextValueAttribute() : base(typeof(IAppContextValue))
        {
        }

        public override void RegisterService(IServiceCollection services, IRegisteContext context, Type declareType)
        {
            services.AddTransient(typeof(IAppContextValue), declareType);
        }
    }
}
