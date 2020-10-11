using System;
using System.Collections.Generic;
using System.Text;

namespace YS.AppContext
{
    public interface IAppContext
    {
        object GetValue(string key);

    }
}
