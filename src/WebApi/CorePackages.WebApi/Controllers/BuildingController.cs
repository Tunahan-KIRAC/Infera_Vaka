using CorePackages.Application.Features.Building.Commands;
using CorePackages.Application.Features.Building.Queries;
using CorePackages.Application.Features.Room.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CorePackages.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {

        private readonly IMediator mediator;
        public BuildingController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var res = new GetAllBuildingQuery();
            return Ok(await mediator.Send(res));
        }


        [HttpGet]

        public async Task<IActionResult> GetById([FromQuery]Guid id)
        {
            var res = new GetByIdBuildingQuery();
            res.Id = id;
            return Ok(await mediator.Send(res));
        }


        [HttpPost]

        public async Task<IActionResult> Add(CreateBuilding command)
        {
            return Ok(await mediator.Send(command));
        }

    }
}
