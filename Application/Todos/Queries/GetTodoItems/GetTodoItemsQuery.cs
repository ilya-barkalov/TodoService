using Application.Todos.Dtos;

using MediatR;

using System.Collections.Generic;

namespace Application.Todos.Queries.GetTodoItems
{
    public class GetTodoItemsQuery : IRequest<List<TodoItemDto>>
    {
    }
}
