using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace disk.Core.Log
{
    public interface IDiskLogProvider
    {
        IDiskLogger GetLogger(String name);
        IDiskLogger GetLogger(Type type);
    }
}
