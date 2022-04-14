using Application.Common.Interfaces;
using Domain.Entities;

using AutoMapper;
using MediatR;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Todos.Commands.Update
{

    internal class UpdateCommandHandler : IRequestHandler<UpdateCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (todoItem == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            todoItem.Name = request.Name;
            todoItem.IsComplete = request.IsComplete;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(request.Id))
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            return Unit.Value;
        }

        private bool TodoItemExists(long id) => _context.TodoItems.Any(e => e.Id == id);
    }
}
