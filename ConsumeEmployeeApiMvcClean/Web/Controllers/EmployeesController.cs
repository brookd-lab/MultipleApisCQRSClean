using ConsumeEmployeeApiMvcClean.Domain.Interfaces;
using ConsumeEmployeeApiMvcClean.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsumeEmployeeApiMvcClean.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeApiClient _apiClient;
        public EmployeesController(IEmployeeApiClient apiClient) => _apiClient = apiClient;

        public async Task<IActionResult> Index()
        {
            var employees = await _apiClient.GetAllAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _apiClient.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid) return View(employee);
            await _apiClient.CreateAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _apiClient.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid) return View(employee);
            await _apiClient.UpdateAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _apiClient.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiClient.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
