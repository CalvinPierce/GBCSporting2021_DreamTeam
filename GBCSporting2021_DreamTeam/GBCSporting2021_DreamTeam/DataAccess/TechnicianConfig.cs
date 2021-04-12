using GBCSporting2021_DreamTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting2021_DreamTeam.DataAccess
{
    internal class TechnicianConfig : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasData(
                new Technician { TechnicianId = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", Phone = "800-555-0443" },
                new Technician { TechnicianId = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", Phone = "800-555-0449" },
                new Technician { TechnicianId = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", Phone = "800-555-0459" },
                new Technician { TechnicianId = 4, Name = "Gunter Wendt", Email = "gunter@sportsprosoftware.com", Phone = "800-555-0400" },
                new Technician { TechnicianId = 5, Name = "Jason Lee", Email = "jason@sportsprosoftware.com", Phone = "800-555-0444" }
                );
        }
    }
}
