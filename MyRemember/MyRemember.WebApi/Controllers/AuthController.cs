using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRemember.Application.UseCases.Auth.Commands.Login;
using MyRemember.Application.UseCases.Auth.Commands.Register;
using MyRemember.Application.UseCases.Auth.Commands.RevokeToken;
using MyRemember.Application.UseCases.Auth.Queries.RefreshToken;
using System.Net;

namespace MyRemember.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginVm))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginVm>> Login(RegisterCommand command, CancellationToken cancellationToken)
        {
            //command.IpAddress = ipAddress();
            //var response = await Mediator?.Send(command, cancellationToken);
            //if (response.RefreshToken != null)
            //{
            //    await setTokenCookie(response.RefreshToken);
            //    response.RefreshToken = null;
            //}
            //return Ok(response);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginVm))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginVm>> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            var newCommand = command with
            {
                IpAddress = ipAddress(),
            };
            var response = await Mediator!.Send(command, cancellationToken);
            if (response.RefreshToken != null) setTokenCookie(response.RefreshToken);
            var newResponse = response with
            {
                RefreshToken = null
            };
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RefreshTokenVm))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RefreshTokenVm>> RefreshToken(CancellationToken cancellationToken)
        {
            var command = new RefreshTokenQuery(ipAddress(), Request.Cookies["refreshToken"]);
            var response = await Mediator!.Send(command, cancellationToken);
            if (response.RefreshToken != null) setTokenCookie(response.RefreshToken);
            var newResponse = response with
            {
                RefreshToken = null
            };
            return Ok(newResponse);
        }

        [Authorize]
        [HttpDelete("revoke-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RevokeToken(CancellationToken cancellationToken)
            => Ok(await Mediator!.Send(new RevokeTokenCommand(ipAddress(), Request.Cookies["refreshToken"]), cancellationToken));

        private void setTokenCookie(string token)
        {
            var expiresTime = _config.GetValue<int>("JwtSettings:ExpirationDaysRefreshToken");
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(expiresTime),
                Secure = false,
                Path = "api/auth/",
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"]!;
            else
                return HttpContext.Connection.RemoteIpAddress!.MapToIPv4().ToString();
        }
    }
}
