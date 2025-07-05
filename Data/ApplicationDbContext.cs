using EmployeeDepartment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartment.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=Api_test;Trusted_Connection=True;TrustServerCertificate=True");
        
    }


    }
}
