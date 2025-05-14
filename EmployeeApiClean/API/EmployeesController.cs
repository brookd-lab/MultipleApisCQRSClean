using EmployeeApiClean.Features.Employees;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeApiClean.API
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRabbitMQProducer _queue;

        public EmployeesController(IMediator mediator, IRabbitMQProducer queue)
        {
            _mediator = mediator;
            _queue = queue;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            var employees = await _mediator.Send(new GetAllEmployeesQuery());
            //await _queue.SendMessage(employees[0], "getall");
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            await _queue.SendMessage(employee, "getbyid");
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var id = await _mediator.Send(command);
            await _queue.SendMessage(command, "Create");
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand command)
        {
            await _mediator.Send(command);
            await _queue.SendMessage(command, "Update");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command);
            await _queue.SendMessage(command, "Delete");
            return NoContent();
        }
    }
}
