using AutoServiceSale.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceSale.Data.Context
{
    public class ApplicationContext : DbContext
    {
       
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1J4BQSR;Database=AutoServiceDB;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
