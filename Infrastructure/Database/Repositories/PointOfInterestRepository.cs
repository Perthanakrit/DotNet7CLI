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
        // เน้นการจัดการข้อมูลที่เกี่ยวกับ Domain Model Province จาก Domain Project
        public PointOfInterestRepository(DatabaseContext context) : base(context)
        {
        }
    }
}