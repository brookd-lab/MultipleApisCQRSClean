using EmployeeApiCQRS.Features.Employees.DTOs;
using EmployeeApiCQRS.Features.Employees.Repos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApiCQRS.Features.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeDto>>
    {
    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery,
        List<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repo;
        public GetAllEmployeesQueryHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request,
            CancellationToken cancellationToken)
        {
            var employees = await _repo.GetEmployeesAsync();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age
            }).ToList();
        }
    }
}

