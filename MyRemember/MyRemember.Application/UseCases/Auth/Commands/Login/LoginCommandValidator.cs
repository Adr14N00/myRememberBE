using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Application.UseCases.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(IStringLocalizer<LoginCommandValidator> localizer)
        {
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(password => password).NotEmpty().WithMessage(localizer["PasswordEmpty"])
                .Must(c => c.Password.Length >= 16).WithMessage(localizer["PasswordTooShort"])
                .Must(c => c.Password != null && c.Password.Any(char.IsUpper)).WithMessage(localizer["PasswordNoUppercase"])
                .Must(c => c.Password != null && c.Password.Any(char.IsLower)).WithMessage(localizer["PasswordNoLowercase"])
                .Must(c => c.Password != null && c.Password.Any(char.IsDigit)).WithMessage(localizer["PasswordNoDigit"])
                .Must(c => c.Password != null && c.Password.Any(c => "!@#$%^&*()".Contains(c))).WithMessage(localizer["PasswordNoSpecial"]);
        }
    }
}
