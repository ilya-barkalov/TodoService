using Application.Common.Interfaces;
using Domain.Entities;

using AutoMapper;
using MediatR;

using System.Threading;
using System.Threading.Tasks;
using Application.Todos.Dtos;

namespace Application.Todos.Commands.Create
{

    internal class CreateCommandHandler : IRequestHandler<CreateCommand, TodoItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoItemDto> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem(request.Name, request.IsComplete);

            await _context.TodoItems.AddAsync(todoItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TodoItemDto>(todoItem);
        }
    }
}
