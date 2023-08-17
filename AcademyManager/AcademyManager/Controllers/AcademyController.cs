using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Academy;
using AcademyManager.Infraestructure.Queries.Academy;
using MediatR;


using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AcademyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<AcademyDto>> GetAllAcademies()
        {
            return await _mediator.Send(new GetAllAcademiesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademyDto>> GetByIdAcademyQuery(int id)
        {
            var query = new GetByIdAcademyQuery(id);
            var academy = await _mediator.Send(query);

            if (academy is null)
            {
                return NotFound();
            }
            return (academy);
        }
        [HttpPost]
        public async Task<ActionResult<AcademyDto>> CreateTecher(CreateAcademyCommand command)
        {
            var academy = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateTecher), new { id = academy.Id }, academy);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAcademy(UpdateAcademyCommand command)
        {
            var academy = await _mediator.Send(command);

            if (academy is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademy(int id)
        {
            var result = await _mediator.Send(new DeleteAcademyCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
