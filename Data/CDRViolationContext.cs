using CheckDrivingDetails.Models;
using CheckDrivingDetails.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckDrivingDetails.Data

{
    public class CDRViolationContext : DbContext    
    {
        public CDRViolationContext(DbContextOptions<CDRViolationContext> options) : base(options)
        {
        }
        public DbSet<DailyDrivingDetail> DailyDrivingDetails { get; set; }
        public DbSet<CDRulesViolation> CDRulesViolations { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CDRulesViolation>()
        //        .HasOne(o => o.DailyDrivingDetails)
        //        .WithMany(DrivingDetail => c.Orders)
        //        .HasForeignKey(o => o.CustomerId);
        //}
       
    }
}
    

