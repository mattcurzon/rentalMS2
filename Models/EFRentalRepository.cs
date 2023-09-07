using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentalMS2.Models
{
    public class EFRentalRepository :IRentalRepository
    {
        private RentalMSDbContext context { get; set; }
        public EFRentalRepository (RentalMSDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Unit> Units => context.Units;
        public IQueryable<Building> Buildings => context.Buildings;
        public IQueryable<Chore> Chores => context.Chores;
        public IQueryable<Manager> Managers => context.Managers;
        public IQueryable<MaitenanceTask> MaitenanceTasks => context.MaitenanceTasks;
        public IQueryable<UnitDeepClean> UnitDeepCleans => context.UnitDeepCleans;

        public void AddDeepClean(UnitDeepClean newClean)
        {
            int maxId = context.UnitDeepCleans.Max(t => t.DeepCleanId);

            int nextId = maxId + 1;

            newClean.DeepCleanId = nextId;
            context.UnitDeepCleans.Add(newClean);
            context.SaveChanges();
        }
        public void AddEarlyCheckIn(EarlyCheckIn newCheckin)
        {
            int maxId = context.EarlyCheckIns.Max(t => t.EarlyCheckInId);

            int nextId = maxId + 1;

            newCheckin.EarlyCheckInId = nextId;
            context.EarlyCheckIns.Add(newCheckin);
            context.SaveChanges();
        }
        public void AddLateCheckOut(LateCheckOut newCheckout)
        {
            int maxId = context.LateCheckOuts.Max(t => t.LateCheckOutId);

            int nextId = maxId + 1;

            newCheckout.LateCheckOutId = nextId;
            context.LateCheckOuts.Add(newCheckout);
            context.SaveChanges();
        }
        public void AddMaitenanceTask(MaitenanceTask newTask)
        {
            int maxId = context.MaitenanceTasks.Max(t => t.MaitenanceId);
            int nextId = maxId + 1;
            newTask.MaitenanceId = nextId;

            newTask.CreatedOn = DateTime.Today;
            newTask.IsCompleted = false;

            context.MaitenanceTasks.Add(newTask);
            context.SaveChanges();
        }
        public void AddChore(Chore newChore)
        {
            int maxId = context.Chores.Max(t => t.ChoreId);
            int nextId = maxId + 1;
            newChore.ChoreId = nextId;

            newChore.CreatedOnDate = DateTime.Today;
            newChore.IsCompleted = false;

            context.Chores.Add(newChore);
            context.SaveChanges();
        }
        public List<MaitenanceTask> GetAllMaitenanceTasks ()
        {
            return context.MaitenanceTasks
                .Where(t => t.IsCompleted == false)
                .ToList();
        }
        public List<Chore> GetAllChores ()
        {
            return context.Chores
                .Where(c => c.IsCompleted == false)
                .ToList();
        }
        public List<UnitDeepClean> GetAllDeepCleans ()
        {
            return context.UnitDeepCleans.ToList();
        }
        public List<Unit> GetUnitsNeedingDeepClean()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var unitsWithoutDeepClean = context.Units
                .Where(unit => !context.UnitDeepCleans
                    .Any(dc => dc.UnitId == unit.UnitId &&
                               dc.DeepCleanDate.Month == currentMonth &&
                               dc.DeepCleanDate.Year == currentYear))
                .ToList();

            return unitsWithoutDeepClean;
        }
        public List<Unit> GetEarlyCheckIns()
        {
            var today = DateTime.Today;

            var earlyCheckIns = context.Units
                .Join(context.EarlyCheckIns,
                u => u.UnitId,
                e => e.UnitId,
                (u, e) => new { Unit = u, EarlyCheckIn = e })
                .Where(joined => joined.EarlyCheckIn.CheckInDate >= today)
                .Select(joined => joined.Unit)
                .ToList();

            return earlyCheckIns;
        }
        public List<Unit> GetLateCheckOuts()
        {
            var today = DateTime.Today;

            var lateCheckOuts = context.Units
                .Join(context.LateCheckOuts,
                u => u.UnitId,
                l => l.UnitId,
                (u, l) => new { Unit = u, LateCheckOut = l })
                .Where(joined => joined.LateCheckOut.CheckOutDate >= today)
                .Select(joined => joined.Unit)
                .ToList();

            return lateCheckOuts;

        }
    }
}
