using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.Enums
{
    public enum Activity
    {

        [Description("فردي")]
        Personal,
        [Description("شركات اونلاين")]
        OnlineInc,
        [Description("شركات قائمة")]
        Inc,
        [Description("محال تجارية")]
        Shops,
        [Description("مطاعم")]
        Resturants

    }
}
