using Application.Common.Interfaces;
using Domain.Entities;

using AutoMapper;
using MediatR;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;

namespace Application.Todos.Commands.Delete
{

    internal class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (todoItem == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
