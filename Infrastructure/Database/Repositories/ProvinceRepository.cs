using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Database;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Province> GetByIdWithPointOfInterestAsync(Guid id)
        {
            return await base._context.Provinces
                        .Include(c => c.PointOfInterests)
                        .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}