using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.Enums
{
    public enum FinancialStatus
    {
        [Description(" تم السداد")]
        Paid,
        [Description("معلق مع السائق")]
       PendingDriver ,
        [Description("معلق مع موصلجي")]
        PendingApp 


    }
}
