using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.DataModels
{
  public  class Employee :BaseDataModel
    {
     /// <summary>
     ///اسم محرر الطلب
     /// </summary> 
        [Required]
        public string EmployeeName { get; set; }
        /// <summary>
        ///كلمة السر 
        /// </summary> 
        [Required]
        public string PasswordHash { get; set; }
      
    }
}
