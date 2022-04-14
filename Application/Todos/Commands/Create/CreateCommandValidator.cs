using FluentValidation;

namespace Application.Todos.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(c => c.Name)
                .MaximumLength(200).WithMessage("Name length shouldn't be greater than 200 characters")
                .NotEmpty().WithMessage("Name must be specified");
        }
    }
}
