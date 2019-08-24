using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.Enums
{
    public enum PaymentMethod
    {
        [Description("WesternUnion")]
        WesternUnion,
        [Description("Zain Cash")]
        ZainCash,
        [Description("اخرى")]
        Others


    }
}
