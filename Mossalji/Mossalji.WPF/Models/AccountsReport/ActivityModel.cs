using Mossalji.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.WPF.Models
{
    public class ActivityModel
    {
        public Activity Activity { get; set; }

        public List<SenderModel>  SenderModels { get; set; }
    }
}
