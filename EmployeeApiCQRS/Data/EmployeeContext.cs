using EmployeeApiCQRS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeApiCQRS.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
