using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.Enums
{
    public enum OrderStatus
    { 
        /// <summary>
        /// قيد التنفيذ
        /// </summary>
        [Description("تحت التنفيذ")]
        Active,
        [Description("تم التنفيذ")]
        Completed,
        [Description("ملغي")]
        Canceled 
    }
}
