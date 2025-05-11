using EmployeeApiClean.Core.Entities;
using EmployeeApiClean.Core.Interfaces;
using EmployeeApiClean.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace EmployeeApiClean.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            return employee!;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            Employee? updatedEmployee = await GetEmployeeByIdAsync(employee.Id);

            if (updatedEmployee == null)
                return;

            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            Employee? employeeToDelete = await GetEmployeeByIdAsync(id);
            if (employeeToDelete == null)
                return;

            _context.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
