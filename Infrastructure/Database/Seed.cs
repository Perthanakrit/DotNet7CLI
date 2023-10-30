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
            Guid khonKeanProvinceId = new Guid("47BA10E2-7FE9-4462-A1C2-5BC84703D4AE");
            Guid bangkokProvinceId = new Guid("F1593F7A-58DF-403E-861D-578B0EE0DFF8");

            if (!context.Provinces.Any())
            {
                List<Province> provinces = new List<Province>()
                {
                    new Province()
                    {
                        Id = khonKeanProvinceId,
                        Name = "ขอนแก่น",
                        CreatedUTC = DateTime.UtcNow,
                        UpdatedUTC = DateTime.UtcNow,
                        Description = "รายละเอียดเพิ่มเติมในจังหวัดขอนแก่น",
                        IsActive = true
                    },
                    new Province()
                    {
                        Id = bangkokProvinceId,
                        Name = "กรุงเทพ",
                        CreatedUTC = DateTime.UtcNow,
                        UpdatedUTC = DateTime.UtcNow,
                        Description = "รายละเอียดเพิ่มเติมในจังหวัดกรุงเทพ",
                        IsActive = true
                    }
                };

                await context.Provinces.AddRangeAsync(provinces);
                await context.SaveChangesAsync();
            }

            if (!context.PointOfInterests.Any())
            {
                List<PointOfInterest> pointOfInterests = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = Guid.NewGuid(),
                        ProvinceId = khonKeanProvinceId,
                        Name = "บึงแก่นนคร",
                        CreatedUTC = DateTime.UtcNow,
                        UpdatedUTC = DateTime.UtcNow,
                        Description = "",
                        IsActive = true
                    },
                    new PointOfInterest()
                    {
                        Id = Guid.NewGuid(),
                        ProvinceId = khonKeanProvinceId,
                        Name = "บึงทุ่งสร้าง",
                        CreatedUTC = DateTime.UtcNow,
                        UpdatedUTC = DateTime.UtcNow,
                        Description = "",
                        IsActive = true
                    },
                    new PointOfInterest()
                    {
                        Id = Guid.NewGuid(),
                        ProvinceId = khonKeanProvinceId,
                        Name = "บึงหนองโครต",
                        CreatedUTC = DateTime.UtcNow,
                        UpdatedUTC = DateTime.UtcNow,
                        Description = "",
                        IsActive = true
                    },
                    new PointOfInterest()
                    {
                        Id = Guid.NewGuid(),
                        ProvinceId = bangkokProvinceId,
                        Name = "สวนลุมพินี",
                        CreatedUTC = DateTime.UtcNow,
                        UpdatedUTC = DateTime.UtcNow,
                        Description = "",
                        IsActive = true
                    },
                    new PointOfInterest()
                    {
                        Id = Guid.NewGuid(),
                        ProvinceId = bangkokProvinceId,
                        Name = "สนามหลวง",
                        CreatedUTC = DateTime.UtcNow,
                        UpdatedUTC = DateTime.UtcNow,
                        Description = "",
                        IsActive = true
                    }
                };


                await context.PointOfInterests.AddRangeAsync(pointOfInterests);
                await context.SaveChangesAsync();
            }
        }
    }
}