using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rentalMS2.Models
{
    [Table("Chore")]
    public partial class Chore
    {
        public Chore() { }

        [Key]
        [Required]
        public int ChoreId { get; set; }
        public int? UnitId { get; set; }
        public string ChoreName { get; set; }
        public string? ChoreDescription { get; set; }
        public string? ChorePriority { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public DateTime? FinishByDate { get; set; }
        public int? BuildingId { get; set; }
        public int? ManagerId { get; set; }
        public bool? IsCompleted { get; set; }

        public Manager? Manager { get; set; }
        public Unit? Unit { get; set; }
        public Building? Building { get; set; }

    }
}
