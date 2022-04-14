using System.Collections.Generic;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Mvc;

using Application.Todos.Dtos;
using Application.Todos.Commands.Create;
using Application.Todos.Commands.Delete;
using Application.Todos.Commands.Update;
using Application.Todos.Queries.GetTodoItem;
using Application.Todos.Queries.GetTodoItems;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            return await _mediator.Send(new GetTodoItemsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(long id)
        {
            var dto = await _mediator.Send(new GetTodoItemQuery(id));
            if (dto == null)
            {
                return NotFound();
            }

            return dto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDto request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var command = new UpdateCommand(id, request.Name, request.IsComplete);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> CreateTodoItem(TodoItemDto request)
        {
            var command = new CreateCommand(request.Name, request.IsComplete);

            var dto = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetTodoItem), new { id = dto.Id }, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            await _mediator.Send(new DeleteCommand(id));

            return NoContent();
        }
    }
}
