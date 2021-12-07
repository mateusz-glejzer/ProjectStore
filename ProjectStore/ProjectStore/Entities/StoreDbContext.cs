using Microsoft.EntityFrameworkCore;
using ProjectStore.Entities;


namespace ProjectStore.Entities
{
    public class StoreDbContext : DbContext
    {

        //public StoreDbContext(DbContextOptions<StoreDbContext> options) :base(options)
        //{

        //}

        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=ProjectStore;Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<User>()
                .Property(u=>u.Username)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.UserId)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();




        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
