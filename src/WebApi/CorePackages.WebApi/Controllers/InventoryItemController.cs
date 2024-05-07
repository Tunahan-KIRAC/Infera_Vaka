using CorePackages.Application.Features.Building.Commands;
using CorePackages.Application.Features.Building.Queries;
using CorePackages.Application.Features.InventoryItem.Commands;
using CorePackages.Application.Features.InventoryItem.Queries;
using CorePackages.Application.Features.Room.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorePackages.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IMediator mediator;
        public InventoryItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var res = new GetAllInventoryItemQuery();
            return Ok(await mediator.Send(res));
        }


        [HttpGet]

        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var res = new GetByIdInventoryItemQuery();
            res.Id = id;
            return Ok(await mediator.Send(res));
        }



        [HttpPost]

        public async Task<IActionResult> Add(CreateInventoryItem command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
