
using Microsoft.EntityFrameworkCore;
using ModelFirstDatabaseusingEntitytest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Services
{
    public class ParkingSiteDbContext : DbContext
    {
        public ParkingSiteDbContext(DbContextOptions<ParkingSiteDbContext> options)
            :base(options)
        {
            Database.Migrate(); //Nuget Microsoft.EntityFrameworkCore.SqlServer --version 3.0.0
        }
        public virtual DbSet<ParkingArea> ParkingAreas { get; set; }
        public virtual DbSet<ParkingSite> ParkingSite { get; set; }
        public virtual DbSet<SiteArea> SiteArea { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiteArea>()
                          .HasKey(sa => new { sa.SiteId, sa.AreaId }); // we have a key
            modelBuilder.Entity<SiteArea>()
           .HasOne(a => a.ParkingArea)
           .WithMany(sa => sa.SiteAreas)
           .HasForeignKey(a => a.AreaId);
            modelBuilder.Entity<SiteArea>()
                .HasOne(s => s.ParkingSite)
                .WithMany(pa => pa.SiteAreas)
                .HasForeignKey(sa => sa.SiteId);
        }
    }
}
