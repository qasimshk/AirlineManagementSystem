using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace airline.management.sharedkernal.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private ISender mediator;
        private IMapper mapper;

        protected ISender _mediator => mediator ??= HttpContext.RequestServices.GetService<ISender>();
        protected IMapper _mapper => mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
