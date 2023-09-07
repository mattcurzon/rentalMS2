using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rentalMS2.Models
{
    [Table("MaitenanceTask")]
    public partial class MaitenanceTask
    {
        public MaitenanceTask() { }

        [Key]
        [Required]
        public int MaitenanceId { get; set; }
        public string Title { get; set; }
        public string? Notes { get; set; }
        public int UnitId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsCompleted { get; set; }

        public Unit Unit { get; set; } = null!;
    }
}
