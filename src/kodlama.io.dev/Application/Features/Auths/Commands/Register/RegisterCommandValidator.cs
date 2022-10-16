using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c=>c.UserForRegisterDto.Email).NotNull().NotEmpty().MaximumLength(100).EmailAddress().WithMessage("EmailAddressFormatError");
        }
    }
}
