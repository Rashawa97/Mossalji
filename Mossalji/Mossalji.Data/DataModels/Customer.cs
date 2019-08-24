using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.DataModels
{
  public class Customer :BaseDataModel
    { /// <summary>
      ///اسم الزبون
      /// </summary> 
        [Required]
        public string CustomerName { get; set; }
        /// <summary>
        ///موقع التوصيل المدينة
        /// </summary> 
        [Required]
        public string City { get; set; }
        /// <summary>
        ///موقع التوصيل المنطقة
        /// </summary> 
        [Required]
        public string Place { get; set; }
        /// <summary>
        ///رقم هاتف الزبون
        /// </summary> 
        [Phone]
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
