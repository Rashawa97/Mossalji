using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.Enums
{
    public enum DriverStatus
    {
        [Description(" سائق خارجي")]
        External,
        [Description("سائق الشركة")]
        Internal

    }
}
