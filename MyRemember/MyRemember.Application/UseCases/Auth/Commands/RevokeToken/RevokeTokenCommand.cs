using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Application.UseCases.Auth.Commands.RevokeToken
{
    public record RevokeTokenCommand(string? RefreshToken, string? IpAddress) : IRequest<Unit>;

}
