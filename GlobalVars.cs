using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHUCheckin
{
    public static class GlobalVars
    {
        public static ILog log = LogManager.GetLogger("HHUCheckin");
    }
}
