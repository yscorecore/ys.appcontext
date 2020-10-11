using System;
using System.Collections.Generic;
using System.Text;

namespace YS.AppContext.Impl.Default
{
    public interface IContextValue
    {
        object Get(IAppContext appContext, IServiceProvider serviceProvider);
        
    }
}
