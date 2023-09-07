using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentalMS2.Models
{
    public interface IRentalRepository
    {
        IQueryable<Unit> Units { get; }
        IQueryable<Building> Buildings { get; }
        IQueryable<Chore> Chores { get; }
        IQueryable<Manager> Managers { get; }
        IQueryable<MaitenanceTask> MaitenanceTasks { get; }
        IQueryable<UnitDeepClean> UnitDeepCleans { get; }

        public void AddDeepClean(UnitDeepClean newClean);
        public void AddEarlyCheckIn(EarlyCheckIn newCheckin);
        public void AddLateCheckOut(LateCheckOut newCheckout);
        public void AddMaitenanceTask(MaitenanceTask newTask);
        public void AddChore(Chore newChore);
        public List<MaitenanceTask> GetAllMaitenanceTasks();
        public List<Chore> GetAllChores();
        public List<UnitDeepClean> GetAllDeepCleans();
        public List<Unit> GetUnitsNeedingDeepClean();
        public List<Unit> GetEarlyCheckIns();
        public List<Unit> GetLateCheckOuts();
    }
}
