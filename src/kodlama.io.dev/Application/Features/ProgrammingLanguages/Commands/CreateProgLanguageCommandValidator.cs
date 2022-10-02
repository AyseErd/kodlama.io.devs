using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class CreateProgLanguageCommandValidator:AbstractValidator<CreateProgLanguageCommand>
    {
        public CreateProgLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
