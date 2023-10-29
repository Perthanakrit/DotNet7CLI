using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Database;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories
{
    public class ProvinceRepository : BaseRepository<Provice>, IProvinceRepository
    {
        public ProvinceRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Provice> GetByIdWithPointOfInterestAsync(Guid id)
        {
            return await base._context.Provinces
                        .Include(c => c.PointOfInterests)
                        .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}