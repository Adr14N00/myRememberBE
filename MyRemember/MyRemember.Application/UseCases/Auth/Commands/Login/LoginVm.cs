using MyRemember.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Application.UseCases.Auth.Commands.Login
{
    public record LoginVm
    (
        bool IsLoggedIn,
        bool? isPasswordSet,
        string? Email,
        UserRole? Role,
        string? Token,
        bool? IsActive
    )
    {
        public string? RefreshToken { get; init; }
    };
}
