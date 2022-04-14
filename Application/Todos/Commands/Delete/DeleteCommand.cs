
using Application.Todos.Dtos;

using MediatR;

namespace Application.Todos.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public DeleteCommand(long id) => Id = id;

        public long Id { get; set; }
    }
}
