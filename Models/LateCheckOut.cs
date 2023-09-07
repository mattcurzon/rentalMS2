using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rentalMS2.Models
{
    [Table("LateCheckOut")]
    public class LateCheckOut
    {
        public LateCheckOut()
        {
        }
        public int LateCheckOutId { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int UnitId { get; set; }

        public Unit Unit { get; set; } = null!;
    }
}
