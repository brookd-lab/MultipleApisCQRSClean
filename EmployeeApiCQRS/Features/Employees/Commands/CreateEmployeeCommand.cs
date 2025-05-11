using EmployeeApiCQRS.Data;
using EmployeeApiCQRS.Features.Employees.DTOs;
using EmployeeApiCQRS.Features.Employees.Repos;
using EmployeeApiCQRS.Models;
using MediatR;

namespace EmployeeApiCQRS.Features.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class CreateEmployeeCommandHandler: IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repo;

        public CreateEmployeeCommandHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = new Employee { Name = command.Name, Age = command.Age };
            await _repo.AddEmployeeAsync(employee);
            return employee.Id;
        }
    }
}
