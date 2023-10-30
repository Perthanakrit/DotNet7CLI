using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        #region DbSet List
        public DbSet<Province> Provinces { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProvinceConfiguration());
            builder.ApplyConfiguration(new PointOfInterestConfiguration());
        }
    }

}