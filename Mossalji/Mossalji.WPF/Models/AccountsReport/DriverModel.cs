using Mossalji.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.WPF.Models
{
    public class DriverModel
    {
        public Driver Driver { get; set; }

        public List<ActivityModel> ActivityModels  {get;set;}
    }
}
