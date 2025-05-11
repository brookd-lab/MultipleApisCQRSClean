using ConsumeEmployeeApiMvcClean.Web.ViewModels;

namespace ConsumeEmployeeApiMvcClean.Domain.Interfaces
{
    public interface IEmployeeApiClient
    {
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task<EmployeeViewModel> GetByIdAsync(int id);
        Task CreateAsync(EmployeeViewModel product);
        Task UpdateAsync(EmployeeViewModel product);
        Task DeleteAsync(int id);
    }
}
