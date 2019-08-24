using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.DataModels
{
    public class BaseDataModel
    {
        /// <summary>
        /// The primary key for the table
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// If this record is deleted
        /// </summary>
        public bool Disabled { get; set; }


    }
}
