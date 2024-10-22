using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Application.UseCases.Auth.Queries.RefreshToken
{
    public record RefreshTokenQuery(string? RefreshToken, string? IpAddress) : IRequest<RefreshTokenVm>;
    
}
