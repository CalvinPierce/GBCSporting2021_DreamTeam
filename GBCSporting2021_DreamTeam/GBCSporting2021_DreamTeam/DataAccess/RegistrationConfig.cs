using GBCSporting2021_DreamTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GBCSporting2021_DreamTeam.DataAccess
{
    internal class RegistrationConfig : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> entity)
        {
            entity.HasData(
                new Registration { RegistrationId = 1, CustomerId = 1, ProductId = 5, RegistrationDate = new DateTime(2021, 2, 21) },
                new Registration { RegistrationId = 2, CustomerId = 1, ProductId = 3, RegistrationDate = new DateTime(2021, 2, 21) }
                );
        }
    }
}
