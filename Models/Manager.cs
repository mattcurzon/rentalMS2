using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rentalMS2.Models
{
    [Table("Manager")]
    public partial class Manager
    {
        public Manager()
        {
        }
        [Key]
        [Required]
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }

        public ICollection<Chore> Chores { get; } = new List<Chore>();
    }
}
