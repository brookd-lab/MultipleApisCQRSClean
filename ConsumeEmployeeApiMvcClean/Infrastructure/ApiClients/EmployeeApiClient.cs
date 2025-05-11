using ConsumeEmployeeApiMvcClean.Domain.Interfaces;
using ConsumeEmployeeApiMvcClean.Web.ViewModels;

namespace ConsumeEmployeeApiMvcClean.Infrastructure.ApiClients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _client;
        public EmployeeApiClient(HttpClient client) => _client = client;
        private const string BASE_API = "employees";

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var response = await _client.GetAsync(BASE_API);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<EmployeeViewModel>>();
        }

        public async Task<EmployeeViewModel> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync($"{BASE_API}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<EmployeeViewModel>();
        }

        public async Task CreateAsync(EmployeeViewModel employee)
        {
            var response = await _client.PostAsJsonAsync(BASE_API, employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(EmployeeViewModel employee)
        {
            var response = await _client.PutAsJsonAsync($"{BASE_API}", employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{BASE_API}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
