using Application.Common.Mappings;

using Domain.Entities;

namespace Application.Todos.Dtos
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
