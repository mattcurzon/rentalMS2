using Microsoft.EntityFrameworkCore;

namespace rentalMS2.Models
{
    public class RentalMSDbContext : DbContext
    {
        public RentalMSDbContext ()
        {

        }

        public RentalMSDbContext (DbContextOptions<RentalMSDbContext> options)
            : base (options)

        {
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<MaitenanceTask> MaitenanceTasks { get; set; }
        public DbSet <Building> Buildings { get; set; }
        public DbSet <UnitDeepClean> UnitDeepCleans { get; set; }
        public DbSet <EarlyCheckIn> EarlyCheckIns { get; set; }
        public DbSet <LateCheckOut> LateCheckOuts { get; set; }


    }
}
