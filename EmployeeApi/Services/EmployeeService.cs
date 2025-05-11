using DAL.Models;
using DAL.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = await _repository.GetEmployeesAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            Employee? employee = await _repository.GetEmployeeByIdAsync(id);
            return employee!;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _repository.AddEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _repository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _repository.DeleteEmployeeAsync(id);
        }
    }
}
