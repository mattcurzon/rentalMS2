using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rentalMS2.Models
{
    [Table("EarlyCheckIn")]
    public partial class EarlyCheckIn
    {
        public EarlyCheckIn()
        {
        }
        [Key]
        [Required]
        public int EarlyCheckInId { get; set; }
        public DateTime CheckInDate { get; set; }
        public int UnitId { get; set; }

        public Unit Unit { get; set; } = null!;

    }
}
