using GBCSporting2021_DreamTeam.Models;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_DreamTeam.DataAccess
{
    public class IncidentContext : DbContext
    {

        public IncidentContext(DbContextOptions<IncidentContext> options)
            : base(options)
        { }

        public DbSet<Incident> Incident { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Registration> Registration { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new IncidentConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new TechnicianConfig());
            modelBuilder.ApplyConfiguration(new RegistrationConfig());

        }
    }
}
