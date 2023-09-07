using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rentalMS2.Models
{
    [Table("Building")]
    public partial class Building
    {
        [Key]
        [Required]
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }

        public ICollection<Unit> Units { get; } = new List<Unit>();
        public ICollection<Chore> Chores { get; } = new List<Chore>();
    }
}
