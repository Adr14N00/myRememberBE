using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyRemember.Application.UseCases.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<LoginVm>
    {
        [JsonIgnore]
        public string? IpAddress { get; init; }
    }
}
