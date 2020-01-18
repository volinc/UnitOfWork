using Business.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.EF
{
    public class DispatcherDbContext : DbContext
    {
        public static readonly ILoggerFactory LoggerFactory =
            Microsoft.Extensions.Logging.LoggerFactory.Create(builder => { builder.AddDebug().AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=.; Database=test-db-dispatcher; User Id=sa; Password=12345(!)a;";
                optionsBuilder
                    .UseLoggerFactory(LoggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(connectionString, providerOptions =>
                {
                    providerOptions.EnableRetryOnFailure();
                });                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCommentData>().ToTable("OrderComments");
        }

        public DbSet<OrderData> Orders { get; set; }

        public DbSet<SuggestionData> Suggestions { get; set; }

        public DbSet<ShiftData> Shifts { get; set; }

        public DbSet<VehicleData> Vehicles { get; set; }

        public DbSet<DriverData> Drivers { get; set; }

    }
}
