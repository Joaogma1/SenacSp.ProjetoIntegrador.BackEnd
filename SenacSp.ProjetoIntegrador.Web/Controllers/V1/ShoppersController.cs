﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Domain.Commands.Shopper;
using SenacSp.ProjetoIntegrador.Shared.Notifications;

namespace SenacSp.ProjetoIntegrador.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/shoppers")]
    public class ShoppersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ShoppersController(IDomainNotification domainNotification, IMediator mediator) : base(domainNotification)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopper(CreateShopperCommand command) =>
            CreateResponse(await _mediator.Send(command, CancellationToken.None));
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> SelfUpdateShopper(UpdateShopperCommand command) =>
            CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}