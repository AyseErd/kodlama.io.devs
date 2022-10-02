using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class UpdateProgLanguageCommandValidator:AbstractValidator<UpdateProgLanguageCommand>
    {
        public UpdateProgLanguageCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
        }
    }
}
