using Mossalji.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.DataModels
{
    public class Order :BaseDataModel
    {
        /// <summary>
        /// نوع الطلب
        /// </summary>
        [Required]
        public string OrderType { get; set; }
        /// <summary>
        /// وصف محتوى الطلب
        /// </summary>
        [Required]
        public string OrderDescription { get; set; }
        /// <summary>
        /// حجم الطلب (طول xعرض x ارتفاع)
        /// </summary>
        [Required]
        public string Volume { get; set; }
        /// <summary>
        ///وزن الطلب
        /// </summary>
        [Required]
        public int Wieght { get; set; }

        /// <summary>
        /// قيمة الطلب
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// اجرة التوصيل كاملة
        /// </summary>
        public double Tax { get; set; }
        /// <summary>
        ///  عمولة موصلجي نسبة
        /// </summary>
        public double MossaljiTaxPercentage { get; set; }
         /// <summary>
         ///  عمولة موصلجي بالدينار                                        
         /// </summary>
        public double MossaljiTaxDinnar { get; set; }// عمولة موصلجي بالدينار

        /// <summary>
        ///  عمولة السائق                                      
        /// </summary>
        public double DeliveryTax { get; set; }
          /// <summary>
          ///  حالة الطلب (تحت التنفيذ/تم التنفيذ/ملغي)                                   
          /// </summary>
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        ///  طريقة السداد للعميل                                     
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }
        /// <summary>
        /// وقت استلام طلب العميل                                   
        /// </summary>
        public DateTime OrderCreationTime { get; set; }
        /// <summary>
        ///وقت تبليغ السائق                                 
        /// </summary>
        public DateTime DriverNotifyingTime { get; set; }
        /// <summary>
        ///وقت استلام السائق للطلب                               
        /// </summary>
        public DateTime PackageReceivingTime { get; set; }
        /// <summary>
        ///وقت استلام الزبون الطلب                          
        /// </summary>
        public DateTime PackageDeleveringTime { get; set; }//وقت استلام الزبون الطلب

        public Driver Driver { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public Client Client { get; set; }



    }
}
