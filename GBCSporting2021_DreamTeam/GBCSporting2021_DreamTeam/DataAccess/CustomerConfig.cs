using GBCSporting2021_DreamTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting2021_DreamTeam.DataAccess
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Kaitlyn",
                    LastName = "Anthoni",
                    Address = "341 Doctors Drive",
                    City = "San Francisco",
                    State = "California",
                    PostalCode = "90017",
                    CountryId = "US",
                    Email = "kanthoni@page.com",
                    Phone = "310-341-3527"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Ania",
                    LastName = "Irvin",
                    Address = "1588 Victoria Park Ave",
                    City = "Toronto",
                    State = "Ontario",
                    PostalCode = "M2J 3T7",
                    CountryId = "CA",
                    Email = "ania@gmail.com",
                    Phone = "416-502-8795"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Gonzalo",
                    LastName = "Keeton",
                    Address = "54 Goldfields Road",
                    City = "Sydney",
                    State = "New South Wales",
                    PostalCode = "4352",
                    CountryId = "AU",
                    Email = "",
                    Phone = ""
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Anton",
                    LastName = "Mauro",
                    Address = "1116 Woodland Terrace",
                    City = "Sacramento",
                    State = "California",
                    PostalCode = "95827",
                    CountryId = "US",
                    Email = "amauro@yahoo.org",
                    Phone = "916-814-8080"
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "Kendall",
                    LastName = "Mayte",
                    Address = "2511 Ingram Street",
                    City = "Dallas",
                    State = "Texas",
                    PostalCode = "97338",
                    CountryId = "US",
                    Email = "kmayte@gmail.com",
                    Phone = "937-521-2309"
                },
                new Customer
                {
                    CustomerId = 6,
                    FirstName = "Kenzie",
                    LastName = "Quinn",
                    Address = "2839 Paradise Lane",
                    City = "Los Angeles",
                    State = "California",
                    PostalCode = "90017",
                    CountryId = "US",
                    Email = "kenzie@mma.jobtrak.com",
                    Phone = "909-610-5168"
                },
                new Customer
                {
                    CustomerId = 7,
                    FirstName = "Marvin",
                    LastName = "Quintin",
                    Address = "1283 40th Street",
                    City = "Calgary",
                    State = "Alberta",
                    PostalCode = "T2k 0P7",
                    CountryId = "CA",
                    Email = "marvin@hotmail.com",
                    Phone = "403-295-6344"
                }
                );
        }
    }
}
