using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentalMS2.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<Chore> Chores { get; set; }
        public List<MaitenanceTask> MaitenanceTasks { get; set; }
        public List<Unit> UnitsNeedingDeepClean { get; set; }
        public List<Unit> UnitsEarlyCheckIn { get; set; }
        public List<Unit> UnitsLateCheckOut { get; set; }
    }
}
