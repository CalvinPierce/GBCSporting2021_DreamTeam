using GBCSporting2021_DreamTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GBCSporting2021_DreamTeam.DataAccess
{
    internal class IncidentConfig : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.HasData(
               new Incident
               {
                   IncidentId = 1,
                   CustomerId = 5,
                   ProductId = 4,
                   Title = "Could not install",
                   Description = "Program fails installation.",
                   TechnicianId = 1,
                   Open = new DateTime(2020, 1, 8),
                   Close = null
               },
                new Incident
                {
                    IncidentId = 2,
                    CustomerId = 3,
                    ProductId = 1,
                    Title = "Could not install",
                    Description = "Program fails installation.",
                    TechnicianId = 1,
                    Open = new DateTime(2020, 1, 8),
                    Close = null
                },
                new Incident
                {
                    IncidentId = 3,
                    CustomerId = 2,
                    ProductId = 2,
                    Title = "Error importing data",
                    Description = "Program fails with error code 610, unable to import data.",
                    TechnicianId = 1,
                    Open = new DateTime(2020, 1, 9),
                    Close = null
                },
                new Incident
                {
                    IncidentId = 4,
                    CustomerId = 5,
                    ProductId = 3,
                    Title = "Error launching program",
                    Description = "Program fails with error code 510, unable to open database.",
                    TechnicianId = 1,
                    Open = new DateTime(2020, 1, 10),
                    Close = null
                }
                );
        }
    }
}
