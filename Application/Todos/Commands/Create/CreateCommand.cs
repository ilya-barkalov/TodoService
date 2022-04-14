
using Application.Todos.Dtos;

using MediatR;

namespace Application.Todos.Commands.Create
{
    public class CreateCommand : IRequest<TodoItemDto>
    {
        public CreateCommand(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }

        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
