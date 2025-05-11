using EmployeeApiCQRS.Data;
using EmployeeApiCQRS.Features.Employees.Repos;
using EmployeeApiCQRS.Models;
using MediatR;

namespace EmployeeApiCQRS.Features.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _repo;
        public UpdateEmployeeCommandHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await _repo.GetEmployeeByIdAsync(request.Id);
            if (employee == null)
                throw new Exception("Employee not found");
            employee.Name = request.Name;
            employee.Age = request.Age;
            await _repo.UpdateEmployeeAsync(employee);
        }
    }
}
