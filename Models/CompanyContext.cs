using Company.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Models
{
    public class CompanyContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
