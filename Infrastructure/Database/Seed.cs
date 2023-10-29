using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Database
{
    public class Seed
    {
        public static async Task SeedData(DatabaseContext context)
        {
            Guid khonKeanProviceId = new Guid("47BA10E2-7FE9-4462-A1C2-5BC84703D4AE");
            Guid bangkokProviceId = new Guid("F1593F7A-58DF-403E-861D-578B0EE0DFF8");

            if (!context.Provinces.Any())
            {
                List<Provice> provinces = new List<Provice>();

                provinces.Add(new Provice()
                {
                    Id = khonKeanProviceId,
                    Name = "ขอนแก่น",
                    CreatedUTC = DateTime.UtcNow,
                    UpdatedUTC = DateTime.UtcNow,
                    Description = "รายละเอียดเพิ่มเติมในจังหวัดขอนแก่น",
                    IsActive = true
                });
                provinces.Add(new Provice()
                {
                    Id = bangkokProviceId,
                    Name = "กรุงเทพ",
                    CreatedUTC = DateTime.UtcNow,
                    UpdatedUTC = DateTime.UtcNow,
                    Description = "รายละเอียดเพิ่มเติมในจังหวัดกรุงเทพ",
                    IsActive = true
                });

                await context.Provinces.AddRangeAsync(provinces);
                await context.SaveChangesAsync();
            }

            if (!context.PointOfInterests.Any())
            {
                List<PointOfInterest> pointOfInterests = new List<PointOfInterest>();

                pointOfInterests.Add(new PointOfInterest()
                {
                    Id = Guid.NewGuid(),
                    ProviceId = khonKeanProviceId,
                    Name = "บึงแก่นนคร",
                    CreatedUTC = DateTime.UtcNow,
                    UpdatedUTC = DateTime.UtcNow,
                    Description = "",
                    IsActive = true
                });
                pointOfInterests.Add(new PointOfInterest()
                {
                    Id = Guid.NewGuid(),
                    ProviceId = khonKeanProviceId,
                    Name = "บึงทุ่งสร้าง",
                    CreatedUTC = DateTime.UtcNow,
                    UpdatedUTC = DateTime.UtcNow,
                    Description = "",
                    IsActive = true
                });
                pointOfInterests.Add(new PointOfInterest()
                {
                    Id = Guid.NewGuid(),
                    ProviceId = khonKeanProviceId,
                    Name = "บึงหนองโครต",
                    CreatedUTC = DateTime.UtcNow,
                    UpdatedUTC = DateTime.UtcNow,
                    Description = "",
                    IsActive = true
                });
                pointOfInterests.Add(new PointOfInterest()
                {
                    Id = Guid.NewGuid(),
                    ProviceId = bangkokProviceId,
                    Name = "สวนลุมพินี",
                    CreatedUTC = DateTime.UtcNow,
                    UpdatedUTC = DateTime.UtcNow,
                    Description = "",
                    IsActive = true
                });
                pointOfInterests.Add(new PointOfInterest()
                {
                    Id = Guid.NewGuid(),
                    ProviceId = bangkokProviceId,
                    Name = "สนามหลวง",
                    CreatedUTC = DateTime.UtcNow,
                    UpdatedUTC = DateTime.UtcNow,
                    Description = "",
                    IsActive = true
                });

                await context.PointOfInterests.AddRangeAsync(pointOfInterests);
                await context.SaveChangesAsync();
            }
        }
    }
}