using Business.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class DispatcherDbContext : DbContext
    {
        public DbSet<OrderData> Orders { get; set; }
        
        public DbSet<SuggestionData> Suggestions { get; set; }

        public DbSet<ShiftData> Shifts { get; set; }

        public DbSet<VehicleData> Vehicles { get; set; }

        public DbSet<DriverData> Drivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(local);Database=test-db-dispather;Trusted_Connection=True;");                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCommentData>().ToTable("OrderComments");
        }
    }
}
