using CorePackages.Application.Features.Building.Commands;
using CorePackages.Application.Features.Building.Queries;
using CorePackages.Application.Features.Depot.Commands;
using CorePackages.Application.Features.Depot.Queries;
using CorePackages.Application.Features.Room.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorePackages.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepotController : ControllerBase
    {
        private readonly IMediator mediator;
        public DepotController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var res = new GetAllDepotQuery();
            return Ok(await mediator.Send(res));
        }


        [HttpGet]

        public async Task<IActionResult> GetById(Guid id)
        {
            var res = new GetByIdDepotQuery();
            res.Id = id;
            return Ok(await mediator.Send(res));
        }



        [HttpPost]

        public async Task<IActionResult> Add(CreateDepot command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
