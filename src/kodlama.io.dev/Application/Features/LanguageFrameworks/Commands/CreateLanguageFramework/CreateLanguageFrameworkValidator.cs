using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.LanguageFrameworks.Commands.CreateLanguageFramework
{
    public class CreateLanguageFrameworkValidator:AbstractValidator<CreateLanguageFrameworkCommand>
    {
        public CreateLanguageFrameworkValidator()
        {
            RuleFor(lf => lf.Name).NotEmpty();
            RuleFor(lf => lf.Name).MinimumLength(1);
        }
    }
}
