using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyRemember.WebApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;
        public IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
