using Microsoft.EntityFrameworkCore;
using System;

namespace GBCSporting2021_DreamTeam.Models
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
            modelBuilder.Entity<Technician>().HasData(
                new Technician { TechnicianId = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", Phone = "800-555-0443" },
                new Technician { TechnicianId = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", Phone = "800-555-0449" },
                new Technician { TechnicianId = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", Phone = "800-555-0459" },
                new Technician { TechnicianId = 4, Name = "Gunter Wendt", Email = "gunter@sportsprosoftware.com", Phone = "800-555-0400" },
                new Technician { TechnicianId = 5, Name = "Jason Lee", Email = "jason@sportsprosoftware.com", Phone = "800-555-0444" }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Kaitlyn", LastName = "Anthoni", Address = "341 Doctors Drive", City = "San Francisco",
                    State = "California", PostalCode = "90017", CountryId = "US", Email = "kanthoni@page.com", Phone = "310-341-3527" },
                new Customer { CustomerId = 2, FirstName = "Ania", LastName = "Irvin", Address = "1588 Victoria Park Ave", City = "Toronto",
                    State = "Ontario", PostalCode = "M2J 3T7", CountryId = "CA", Email = "ania@gmail.com", Phone = "416-502-8795" },
                new Customer { CustomerId = 3, FirstName = "Gonzalo", LastName = "Keeton", Address = "54 Goldfields Road", City = "Sydney",
                    State = "New South Wales", PostalCode = "4352", CountryId = "AU", Email = "", Phone = "" },
                new Customer { CustomerId = 4, FirstName = "Anton", LastName = "Mauro", Address = "1116 Woodland Terrace", City = "Sacramento",
                    State = "California", PostalCode = "95827", CountryId = "US", Email = "amauro@yahoo.org", Phone = "916-814-8080" },
                new Customer { CustomerId = 5, FirstName = "Kendall", LastName = "Mayte", Address = "2511 Ingram Street", City = "Dallas",
                    State = "Texas", PostalCode = "97338", CountryId = "US", Email = "kmayte@gmail.com", Phone = "937-521-2309" },
                new Customer { CustomerId = 6, FirstName = "Kenzie", LastName = "Quinn", Address = "2839 Paradise Lane", City = "Los Angeles",
                    State = "California", PostalCode = "90017", CountryId = "US", Email = "kenzie@mma.jobtrak.com", Phone = "909-610-5168" },
                new Customer { CustomerId = 7, FirstName = "Marvin", LastName = "Quintin", Address = "1283 40th Street", City = "Calgary",
                    State = "Alberta", PostalCode = "T2k 0P7", CountryId = "CA", Email = "marvin@hotmail.com", Phone = "403-295-6344" }
            );
            modelBuilder.Entity<Products>().HasData(
               new Products { ProductId = 1, ProductCode = "TRNY10", Name = "Tournament Master 1.0", Price = 4.99, ReleaseDate = new DateTime(2015, 12, 1) },
               new Products { ProductId = 2, ProductCode = "LEAG10", Name = "League Scheduler 1.0", Price = 4.99, ReleaseDate = new DateTime(2016, 5, 1) },
               new Products { ProductId = 3, ProductCode = "LEAGD10", Name = "League Scheduler Deluxe 1.0", Price = 7.99, ReleaseDate = new DateTime(2016, 8, 1) },
               new Products { ProductId = 4, ProductCode = "DRAFT10", Name = "Draft Manager 1.0", Price = 4.99, ReleaseDate = new DateTime(2017, 2, 1) },
               new Products { ProductId = 5, ProductCode = "TEAM10", Name = "Team Manager 1.0", Price = 4.99, ReleaseDate = new DateTime(2017, 5, 1) },
               new Products { ProductId = 6, ProductCode = "TRNY20", Name = "Tournament Master 2.0", Price = 5.99, ReleaseDate = new DateTime(2018, 2, 15) },
               new Products { ProductId = 7, ProductCode = "DRAFT20", Name = "Draft Manager 2.0", Price = 5.99, ReleaseDate = new DateTime(2019, 7, 19) }
            );
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = "CA", Name = "Canada" },
                new Country { CountryId = "FR", Name = "France" },
                new Country { CountryId = "US", Name = "United States" },
                new Country { CountryId = "EN", Name = "England" },
                new Country { CountryId = "ME", Name = "Mexico" },
                new Country { CountryId = "CH", Name = "China" },
                new Country { CountryId = "GE", Name = "Germany" },
                new Country { CountryId = "IT", Name = "Italy" },
                new Country { CountryId = "IN", Name = "India" },
                new Country { CountryId = "AU", Name = "Australia" }
            );
            modelBuilder.Entity<Incident>().HasData(
                new Incident { IncidentId = 1, CustomerId = 5, ProductId = 4, Title = "Could not install", Description = "Program fails installation.",
                    TechnicianId = 1, Open = new DateTime(2020, 1, 8), Close = null },
                new Incident { IncidentId = 2, CustomerId = 3, ProductId = 1, Title = "Could not install", Description = "Program fails installation.",
                    TechnicianId = 1, Open = new DateTime(2020, 1, 8), Close = null },
                new Incident { IncidentId = 3, CustomerId = 2, ProductId = 2, Title = "Error importing data", Description = "Program fails with error code 610, unable to import data.",
                    TechnicianId = 1, Open = new DateTime(2020, 1, 9), Close = null },
                new Incident { IncidentId = 4, CustomerId = 5, ProductId = 3, Title = "Error launching program", Description = "Program fails with error code 510, unable to open database.",
                    TechnicianId = 1, Open = new DateTime(2020, 1, 10), Close = null }
            );
            modelBuilder.Entity<Registration>().HasData(
                new Registration { RegistrationId = 1, CustomerId = 1, ProductId = 5, RegistrationDate = new DateTime(2021, 2, 21) },
                new Registration { RegistrationId = 2, CustomerId = 1, ProductId = 3, RegistrationDate = new DateTime(2021, 2, 21) }
            );
        }
    }
}
