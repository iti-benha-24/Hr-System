using Hr_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Hr_System.Data
{
    public class HrDbContext : IdentityDbContext<ApplicationUser, CustomRole,string>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<PublicHolidays> PublicHolidays { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<CustomRole> Roles { get; set; }
        public HrDbContext(DbContextOptions<HrDbContext> options):base(options)
        {
            
        }
        public HrDbContext()
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GeneralSettings>()
           .HasOne(gs => gs.Employee)
           .WithOne(e => e.GeneralSettings)
           .HasForeignKey<GeneralSettings>(gs => gs.EmployeeId)
           .OnDelete(DeleteBehavior.Cascade);
                }
    }
}
