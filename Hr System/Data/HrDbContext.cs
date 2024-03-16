using Hr_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hr_System.Data
{
    public class HrDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<Weekend> Weekends { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<PublicHolidays> PublicHolidays { get; set; }
        public HrDbContext(DbContextOptions<HrDbContext> options):base(options)
        {
            
        }
        public HrDbContext()
        {
            
        }
    }
}
