using EmployeeApiClean.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeApiClean.Infrastructure.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
