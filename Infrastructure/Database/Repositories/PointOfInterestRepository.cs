using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Database;
using Domain.Entities;

namespace Infrastructure.Database.Repositories
{
    public class PointOfInterestRepository : BaseRepository<PointOfInterest>, IPointOfInterestRepository
    {
        public PointOfInterestRepository(DatabaseContext context) : base(context)
        {
        }
    }
}