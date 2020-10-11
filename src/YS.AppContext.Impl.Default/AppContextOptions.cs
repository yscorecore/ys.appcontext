using System;
using System.Collections.Generic;
using System.Text;
using YS.Knife;

namespace YS.AppContext.Impl.Default
{
    [Options]
    public class AppContextOptions
    {
        public Dictionary<string, List<string>> Aliases { get; set; }

        public IDictionary<string, Func<IServiceProvider, IAppContext, object>> Values { get; } =
            new Dictionary<string, Func<IServiceProvider, IAppContext, object>>();
    }
}
