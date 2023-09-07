using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rentalMS2.Models
{
    [Table("UnitDeepClean")]
    public partial class UnitDeepClean
    {
        public UnitDeepClean()
        {
        }
        [Key]
        [Required]
        public int DeepCleanId { get; set; }
        public DateTime DeepCleanDate { get; set; }
        public int UnitId { get; set; }

        public Unit Unit { get; set; } = null!;
    }
}
