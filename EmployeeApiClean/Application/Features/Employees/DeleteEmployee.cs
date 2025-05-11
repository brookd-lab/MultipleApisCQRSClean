using EmployeeApiClean.Core.Interfaces;
using MediatR;

namespace EmployeeApiClean.Features.Employees
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _repo;
        public DeleteEmployeeCommandHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await _repo.GetEmployeeByIdAsync(request.Id);
            if (employee == null)
                throw new Exception("Employee not found");
            await _repo.DeleteEmployeeAsync(request.Id);
        }
    }
}
