using GBCSporting2021_DreamTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GBCSporting2021_DreamTeam.DataAccess
{
    internal class ProductConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> entity)
        {
            entity.HasData(
               new Products { ProductId = 1, ProductCode = "TRNY10", Name = "Tournament Master 1.0", Price = 4.99, ReleaseDate = new DateTime(2015, 12, 1) },
               new Products { ProductId = 2, ProductCode = "LEAG10", Name = "League Scheduler 1.0", Price = 4.99, ReleaseDate = new DateTime(2016, 5, 1) },
               new Products { ProductId = 3, ProductCode = "LEAGD10", Name = "League Scheduler Deluxe 1.0", Price = 7.99, ReleaseDate = new DateTime(2016, 8, 1) },
               new Products { ProductId = 4, ProductCode = "DRAFT10", Name = "Draft Manager 1.0", Price = 4.99, ReleaseDate = new DateTime(2017, 2, 1) },
               new Products { ProductId = 5, ProductCode = "TEAM10", Name = "Team Manager 1.0", Price = 4.99, ReleaseDate = new DateTime(2017, 5, 1) },
               new Products { ProductId = 6, ProductCode = "TRNY20", Name = "Tournament Master 2.0", Price = 5.99, ReleaseDate = new DateTime(2018, 2, 15) },
               new Products { ProductId = 7, ProductCode = "DRAFT20", Name = "Draft Manager 2.0", Price = 5.99, ReleaseDate = new DateTime(2019, 7, 19) }
                );
        }
    }
}
