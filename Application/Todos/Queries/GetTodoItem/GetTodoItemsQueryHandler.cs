using Application.Common.Interfaces;
using Application.Todos.Dtos;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todos.Queries.GetTodoItem
{
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoItemDto> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems
                .FindAsync(new object[] { request.Id }, cancellationToken);
                
            return _mapper.Map<TodoItemDto>(entity);
        }
    }
}
