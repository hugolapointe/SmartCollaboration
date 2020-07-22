using Application.Common.Interfaces;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {

    [ApiController]
    public class ApiController : ControllerBase {
        protected readonly IMediator mediator;
        protected readonly IApplicationDbContext context;

        public ApiController(IMediator mediator, IApplicationDbContext context) {
            this.mediator = mediator;
            this.context = context;
        }
    }
}
