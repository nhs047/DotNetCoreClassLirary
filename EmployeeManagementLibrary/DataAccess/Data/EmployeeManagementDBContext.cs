using EmployeeManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementLibrary.DataAccess.Data
{
    public class EmployeeManagementDBContext: DbContext
    {
        public EmployeeManagementDBContext(DbContextOptions<EmployeeManagementDBContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleMap> UserRoleMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasOne(m => m.UserMapper)
                        .WithMany(t => t.UserIds)
                        .HasForeignKey(m => m.UserID)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Employee>()
                        .HasOne(m => m.UserMapper2)
                        .WithMany(t => t.ManagerIds)
                        .HasForeignKey(m => m.ManagerID)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}