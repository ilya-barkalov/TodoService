using FluentValidation;

namespace Application.Todos.Commands.Delete
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("TodoItem Id must be specified");
        }
    }
}
