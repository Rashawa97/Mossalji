using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.Enums
{
    public enum CarStatus
    {
       
        [Description(" سيارة خارجية " )]
        ExternalCar,
        [Description("سيارة الشركة")]
        InternalCar

    }
}
