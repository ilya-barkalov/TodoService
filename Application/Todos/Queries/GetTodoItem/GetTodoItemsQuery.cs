using Application.Todos.Dtos;

using MediatR;

namespace Application.Todos.Queries.GetTodoItem
{
    public class GetTodoItemQuery : IRequest<TodoItemDto>
    {
        public GetTodoItemQuery(long id) => Id = id;

        public long Id { get; set; }
    }
}
