using DAL.Models;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return employee;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(Employee employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeAsync(Employee employee) {
            var foundEmployee = await GetEmployeeByIdAsync(employee.Id);
            if (foundEmployee == null)
                return NotFound();

            await _employeeService.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var foundEmployee = await GetEmployeeByIdAsync(id);
            if (foundEmployee == null)
                return NotFound();

            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
