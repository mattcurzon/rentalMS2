using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rentalMS2.Models
{
    [Table("Unit")]
    public partial class Unit
    {
        public Unit()
        {
        }

        [Key]
        [Required]
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int BuildingId { get; set; }

        public Building Building { get; set; } = null!;
        public ICollection<MaitenanceTask> MaitenanceTasks { get;} = new List<MaitenanceTask>();
        public ICollection<Chore> Chores { get;} = new List<Chore>();
        public ICollection<UnitDeepClean> UnitDeepCleans { get; } = new List<UnitDeepClean>();
        public ICollection<EarlyCheckIn> EarlyCheckIns { get; } = new List<EarlyCheckIn>();
        public ICollection<LateCheckOut> LateCheckOuts { get; } = new List<LateCheckOut>();

    }
}
