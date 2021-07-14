using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Universum.DMISCQRS.Application.Features.Professors;
namespace Universum.DMISCQRS.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new Get.Query());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Add.Command command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
