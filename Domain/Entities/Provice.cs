using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provice : BaseEntity, IBaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        #region Entity Framework Relationships
        public ICollection<PointOfInterest>? PointOfInterests { get; set; }
        #endregion
    }
}