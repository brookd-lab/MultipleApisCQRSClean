using EmployeeApiClean.Application.DTOs;
using EmployeeApiClean.Core.Interfaces;
using MediatR;

namespace EmployeeApiClean.Features.Employees
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery,
        EmployeeDto>
    {
        private readonly IEmployeeRepository _repo;
        public GetEmployeeByIdHandler(IEmployeeRepository repo) 
        { 
            _repo = repo;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request,
            CancellationToken cancellationToken)
        {
            var employee = await _repo.GetEmployeeByIdAsync(request.Id);
            if (employee == null) return null!;
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age
            };
        }
    }
}
