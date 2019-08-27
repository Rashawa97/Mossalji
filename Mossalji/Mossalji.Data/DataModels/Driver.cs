using Mossalji.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.DataModels
{
    public class Driver : BaseDataModel
    {     /// <summary>
          ///اسم السائق
          /// </summary> 
        [Required]
        public string DriverName { get; set; }
        /// <summary>
        ///حالةالسائق(سائق خارجي /سائق الشركة) 
        /// </summary> 
        [Required]
        public DriverStatus DriverStatus { get; set; }
        /// <summary>
        ///حالة السيارة (سيارة الشركة /سيارة خارجي)
        /// </summary> 
        [Required]
        public CarStatus CarStatus { get; set; }
        /// <summary>
        ///رقم السيارة
        /// </summary> 
        [Required]
        public string CarNumber { get; set; }
        public ICollection<Order> Orders { get; set; }


        public override string ToString()
        {
            return $"{DriverName} - {CarNumber}";
        }
    }
}
