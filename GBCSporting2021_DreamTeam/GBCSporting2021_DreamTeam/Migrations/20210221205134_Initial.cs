using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCSporting2021_DreamTeam.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    Open = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Close = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incident_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registration_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { "CA", "Canada" },
                    { "FR", "France" },
                    { "US", "United States" },
                    { "EN", "England" },
                    { "ME", "Mexico" },
                    { "CH", "China" },
                    { "GE", "Germany" },
                    { "IT", "Italy" },
                    { "IN", "India" },
                    { "AU", "Australia" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "ProductCode", "ReleaseDate" },
                values: new object[,]
                {
                    { 7, "Draft Manager 2.0", 5.9900000000000002, "DRAFT20", new DateTime(2019, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Tournament Master 2.0", 5.9900000000000002, "TRNY20", new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Team Manager 1.0", 4.9900000000000002, "TEAM10", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Tournament Master 1.0", 4.9900000000000002, "TRNY10", new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "League Scheduler Deluxe 1.0", 7.9900000000000002, "LEAGD10", new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "League Scheduler 1.0", 4.9900000000000002, "LEAG10", new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Draft Manager 1.0", 4.9900000000000002, "DRAFT10", new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 4, "gunter@sportsprosoftware.com", "Gunter Wendt", "800-555-0400" },
                    { 1, "alison@sportsprosoftware.com", "Alison Diaz", "800-555-0443" },
                    { 2, "awilson@sportsprosoftware.com", "Andrew Wilson", "800-555-0449" },
                    { 3, "gfiori@sportsprosoftware.com", "Gina Fiori", "800-555-0459" },
                    { 5, "jason@sportsprosoftware.com", "Jason Lee", "800-555-0444" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 2, "1588 Victoria Park Ave", "Toronto", "CA", "ania@gmail.com", "Ania", "Irvin", "416-502-8795", "M2J 3T7", "Ontario" },
                    { 7, "1283 40th Street", "Calgary", "CA", "marvin@hotmail.com", "Marvin", "Quintin", "403-295-6344", "T2k 0P7", "Alberta" },
                    { 1, "341 Doctors Drive", "San Francisco", "US", "kanthoni@page.com", "Kaitlyn", "Anthoni", "310-341-3527", "90017", "California" },
                    { 4, "1116 Woodland Terrace", "Sacramento", "US", "amauro@yahoo.org", "Anton", "Mauro", "916-814-8080", "95827", "California" },
                    { 5, "2511 Ingram Street", "Dallas", "US", "kmayte@gmail.com", "Kendall", "Mayte", "937-521-2309", "97338", "Texas" },
                    { 6, "2839 Paradise Lane", "Los Angeles", "US", "kenzie@mma.jobtrak.com", "Kenzie", "Quinn", "909-610-5168", "90017", "California" },
                    { 3, "54 Goldfields Road", "Sydney", "AU", "", "Gonzalo", "Keeton", "", "4352", "New South Wales" }
                });

            migrationBuilder.InsertData(
                table: "Incident",
                columns: new[] { "IncidentId", "Close", "CustomerId", "Description", "Open", "ProductId", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 3, null, 2, "Program fails with error code 610, unable to import data.", new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Error importing data" },
                    { 1, null, 5, "Program fails installation.", new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, "Could not install" },
                    { 4, null, 5, "Program fails with error code 510, unable to open database.", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "Error launching program" },
                    { 2, null, 3, "Program fails installation.", new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Could not install" }
                });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "RegistrationId", "CustomerId", "ProductId", "RegistrationDate" },
                values: new object[] { 1, 1, 5, new DateTime(2021, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_CustomerId",
                table: "Incident",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_ProductId",
                table: "Incident",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_TechnicianId",
                table: "Incident",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_CustomerId",
                table: "Registration",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_ProductId",
                table: "Registration",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
