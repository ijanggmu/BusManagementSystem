using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Bus.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    
    public abstract class BaseApiController:ControllerBase
    {
        private  IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
