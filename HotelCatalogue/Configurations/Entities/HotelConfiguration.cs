using HotelCatalogue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCatalogue.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                 new Hotel
                 {
                     Id = 1,
                     Name = "Brazil Hotel",
                     Address = "Bahia",
                     CountryId = 1,
                     Rating = 4.5
                 },
                new Hotel
                {
                    Id = 2,
                    Name = "United States of America Hotel",
                    Address = "Ohio",
                    CountryId = 2,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Canada Hotel",
                    Address = "Toronto",
                    CountryId = 3,
                    Rating = 4.5
                });
        }
    }
}
