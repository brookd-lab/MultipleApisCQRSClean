using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DAL.Repos
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
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

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            Employee? updatedEmployee = await GetEmployeeByIdAsync(employee.Id);

            if (updatedEmployee == null)
                return;

            updatedEmployee.Name = employee.Name;
            updatedEmployee.Age = employee.Age;

            _context.Update(updatedEmployee);
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
