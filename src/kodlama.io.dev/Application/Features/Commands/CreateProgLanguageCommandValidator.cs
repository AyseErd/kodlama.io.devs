using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Commands
{
    public class CreateProgLanguageCommandValidator:AbstractValidator<CreateProgLanguageCommand>
    {
        public CreateProgLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
