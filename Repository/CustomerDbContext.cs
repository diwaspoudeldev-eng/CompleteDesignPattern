using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CustomerDbContext : DbContext
    {
        private readonly string _connectionString;

        public CustomerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .ToTable("Customers")
                .HasKey(c => c.CustomerName);
        }
    }
}
