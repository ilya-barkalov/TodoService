using FluentValidation;

namespace Application.Todos.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("TodoItem Id must be specified");

            RuleFor(c => c.Name)
                .MaximumLength(200).WithMessage("Name length shouldn't be greater than 200 characters")
                .NotEmpty().WithMessage("Name must be specified");
        }
    }
}
