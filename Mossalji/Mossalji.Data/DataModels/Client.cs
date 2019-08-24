using Mossalji.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.DataModels
{
  public  class Client :BaseDataModel
    { /// <summary>
      /// اسم العميل
      /// </summary>
        [Required]
        public string ClientName { get; set; }
        /// <summary>
        /// موقع العميل المدينه
        /// </summary>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// موقع العميل المنطقة
        /// </summary>
        [Required]
        public string Place { get; set; }
        /// <summary>
        /// تاريخ استلام الطلب
        /// </summary>
        [Required]
        public string OrderDateTime { get; set; }
        /// <summary>
        /// نشاط العميل
        /// </summary>
        [Required]
        public string Activity { get; set; }

        /// <summary>
        ///      ذمم ماليه للعميل
        /// </summary>
        public FinancialStatus FinancialStatus { get; set; }
     

        public ICollection<Order> Orders { get; set; }
    }
}
