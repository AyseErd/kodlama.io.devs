using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Commands
{
    public class UpdateProgLanguageCommandValidator:AbstractValidator<UpdateProgLanguageCommand>
    {
        public UpdateProgLanguageCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
        }
    }
}
