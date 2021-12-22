using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    /// <summary>
    /// clase la cual permite que al heredar del controlador se pueda usar la inyeccion de dependencias del mediador //nugget MediaTR
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]//para manejar versionamiento
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
