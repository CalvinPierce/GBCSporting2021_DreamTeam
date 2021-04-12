using GBCSporting2021_DreamTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting2021_DreamTeam.DataAccess
{
    internal class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(
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
        }
    }
}
