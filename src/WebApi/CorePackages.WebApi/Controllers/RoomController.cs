using CorePackages.Application.Features.InventoryItem.Commands;
using CorePackages.Application.Features.InventoryItem.Queries;
using CorePackages.Application.Features.Room.Commands;
using CorePackages.Application.Features.Room.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorePackages.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator mediator;
        public RoomController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var res = new GetAllRoomQuery();
            return Ok(await mediator.Send(res));
        }

        [HttpGet]

        public async Task<IActionResult> GetById(Guid id)
        {
            var res = new GetByIdRoomQuery();
            res.Id = id;
            return Ok(await mediator.Send(res));
        }

        [HttpPost]

        public async Task<IActionResult> Add(CreateRoom command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
