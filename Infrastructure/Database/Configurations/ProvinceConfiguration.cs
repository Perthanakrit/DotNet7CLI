using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Provice>
    {
        public void Configure(EntityTypeBuilder<Provice> builder)
        {
            throw new NotImplementedException();
        }
    }
}