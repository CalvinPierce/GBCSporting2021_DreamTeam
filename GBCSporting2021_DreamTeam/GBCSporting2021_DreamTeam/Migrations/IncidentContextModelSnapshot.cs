﻿// <auto-generated />
using System;
using GBCSporting2021_DreamTeam.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GBCSporting2021_DreamTeam.Migrations
{
    [DbContext(typeof(IncidentContext))]
    partial class IncidentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Country", b =>
                {
                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = "CA",
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = "FR",
                            Name = "France"
                        },
                        new
                        {
                            CountryId = "US",
                            Name = "United States"
                        },
                        new
                        {
                            CountryId = "EN",
                            Name = "England"
                        },
                        new
                        {
                            CountryId = "ME",
                            Name = "Mexico"
                        },
                        new
                        {
                            CountryId = "CH",
                            Name = "China"
                        },
                        new
                        {
                            CountryId = "GE",
                            Name = "Germany"
                        },
                        new
                        {
                            CountryId = "IT",
                            Name = "Italy"
                        },
                        new
                        {
                            CountryId = "IN",
                            Name = "India"
                        },
                        new
                        {
                            CountryId = "AU",
                            Name = "Australia"
                        });
                });

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "341 Doctors Drive",
                            City = "San Francisco",
                            CountryId = "US",
                            Email = "kanthoni@page.com",
                            FirstName = "Kaitlyn",
                            LastName = "Anthoni",
                            Phone = "310-341-3527",
                            PostalCode = "90017",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "1588 Victoria Park Ave",
                            City = "Toronto",
                            CountryId = "CA",
                            Email = "ania@gmail.com",
                            FirstName = "Ania",
                            LastName = "Irvin",
                            Phone = "416-502-8795",
                            PostalCode = "M2J 3T7",
                            State = "Ontario"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "54 Goldfields Road",
                            City = "Sydney",
                            CountryId = "AU",
                            Email = "",
                            FirstName = "Gonzalo",
                            LastName = "Keeton",
                            Phone = "",
                            PostalCode = "4352",
                            State = "New South Wales"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "1116 Woodland Terrace",
                            City = "Sacramento",
                            CountryId = "US",
                            Email = "amauro@yahoo.org",
                            FirstName = "Anton",
                            LastName = "Mauro",
                            Phone = "916-814-8080",
                            PostalCode = "95827",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 5,
                            Address = "2511 Ingram Street",
                            City = "Dallas",
                            CountryId = "US",
                            Email = "kmayte@gmail.com",
                            FirstName = "Kendall",
                            LastName = "Mayte",
                            Phone = "937-521-2309",
                            PostalCode = "97338",
                            State = "Texas"
                        },
                        new
                        {
                            CustomerId = 6,
                            Address = "2839 Paradise Lane",
                            City = "Los Angeles",
                            CountryId = "US",
                            Email = "kenzie@mma.jobtrak.com",
                            FirstName = "Kenzie",
                            LastName = "Quinn",
                            Phone = "909-610-5168",
                            PostalCode = "90017",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 7,
                            Address = "1283 40th Street",
                            City = "Calgary",
                            CountryId = "CA",
                            Email = "marvin@hotmail.com",
                            FirstName = "Marvin",
                            LastName = "Quintin",
                            Phone = "403-295-6344",
                            PostalCode = "T2k 0P7",
                            State = "Alberta"
                        });
                });

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Close")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Open")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incident");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 5,
                            Description = "Program fails installation.",
                            Open = new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 4,
                            TechnicianId = 1,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 3,
                            Description = "Program fails installation.",
                            Open = new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentId = 3,
                            CustomerId = 2,
                            Description = "Program fails with error code 610, unable to import data.",
                            Open = new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 2,
                            TechnicianId = 1,
                            Title = "Error importing data"
                        },
                        new
                        {
                            IncidentId = 4,
                            CustomerId = 5,
                            Description = "Program fails with error code 510, unable to open database.",
                            Open = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 3,
                            TechnicianId = 1,
                            Title = "Error launching program"
                        });
                });

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Tournament Master 1.0",
                            Price = 4.9900000000000002,
                            ProductCode = "TRNY10",
                            ReleaseDate = new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "League Scheduler 1.0",
                            Price = 4.9900000000000002,
                            ProductCode = "LEAG10",
                            ReleaseDate = new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "League Scheduler Deluxe 1.0",
                            Price = 7.9900000000000002,
                            ProductCode = "LEAGD10",
                            ReleaseDate = new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "Draft Manager 1.0",
                            Price = 4.9900000000000002,
                            ProductCode = "DRAFT10",
                            ReleaseDate = new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "Team Manager 1.0",
                            Price = 4.9900000000000002,
                            ProductCode = "TEAM10",
                            ReleaseDate = new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 6,
                            Name = "Tournament Master 2.0",
                            Price = 5.9900000000000002,
                            ProductCode = "TRNY20",
                            ReleaseDate = new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 7,
                            Name = "Draft Manager 2.0",
                            Price = 5.9900000000000002,
                            ProductCode = "DRAFT20",
                            ReleaseDate = new DateTime(2019, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RegistrationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Registration");

                    b.HasData(
                        new
                        {
                            RegistrationId = 1,
                            CustomerId = 1,
                            ProductId = 5,
                            RegistrationDate = new DateTime(2021, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "alison@sportsprosoftware.com",
                            Name = "Alison Diaz",
                            Phone = "800-555-0443"
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "awilson@sportsprosoftware.com",
                            Name = "Andrew Wilson",
                            Phone = "800-555-0449"
                        },
                        new
                        {
                            TechnicianId = 3,
                            Email = "gfiori@sportsprosoftware.com",
                            Name = "Gina Fiori",
                            Phone = "800-555-0459"
                        },
                        new
                        {
                            TechnicianId = 4,
                            Email = "gunter@sportsprosoftware.com",
                            Name = "Gunter Wendt",
                            Phone = "800-555-0400"
                        },
                        new
                        {
                            TechnicianId = 5,
                            Email = "jason@sportsprosoftware.com",
                            Name = "Jason Lee",
                            Phone = "800-555-0444"
                        });
                });

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Customer", b =>
                {
                    b.HasOne("GBCSporting2021_DreamTeam.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Incident", b =>
                {
                    b.HasOne("GBCSporting2021_DreamTeam.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting2021_DreamTeam.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting2021_DreamTeam.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("GBCSporting2021_DreamTeam.Models.Registration", b =>
                {
                    b.HasOne("GBCSporting2021_DreamTeam.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting2021_DreamTeam.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
