using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Application.UseCases.Auth.Queries.RefreshToken
{
    public record RefreshTokenVm
    (
        string? Email,
        string? Role,
        string? Token,
        string? RefreshToken
    );
}
