using Microsoft.EntityFrameworkCore;
using LeaveManagementAPI.Models;

namespace LeaveManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee>     Employees     { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}