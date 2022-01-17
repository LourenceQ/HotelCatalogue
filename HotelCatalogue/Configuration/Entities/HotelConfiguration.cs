using HotelCatalogue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCatalogue.Configuration.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel { Id = 1, Name = "Hotel Ouro Preto", Address = "Minas Gerais", CountryId = 1, Rating = 5 },
                new Hotel { Id = 2, Name = "Hotel Snowy Mountain", Address = "Toronto", CountryId = 2, Rating = 4.8 },
                new Hotel { Id = 3, Name = "Hotel Sherburg", Address = "Paris", CountryId = 3, Rating = 4.9 }
                );
        }
    }
}
