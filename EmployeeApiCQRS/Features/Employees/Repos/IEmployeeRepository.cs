using EmployeeApiCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApiCQRS.Features.Employees.Repos
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
