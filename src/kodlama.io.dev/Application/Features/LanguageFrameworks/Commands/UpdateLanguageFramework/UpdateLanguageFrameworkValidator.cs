using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.LanguageFrameworks.Commands.UpdateLanguageFramework
{
    public class UpdateLanguageFrameworkValidator:AbstractValidator<UpdateLanguageFrameworkCommand>
    {
        public UpdateLanguageFrameworkValidator()
        {
            RuleFor(lf => lf.Name).NotEmpty();
            RuleFor(lf => lf.Name).MinimumLength(1);
        }
    }
}
