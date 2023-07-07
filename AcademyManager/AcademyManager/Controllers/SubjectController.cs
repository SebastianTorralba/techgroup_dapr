using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Subject;
using AcademyManager.Infraestructure.Queries.Subject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectDto>> GetAllSubjects()
        {
            return await _mediator.Send(new GetAllSubjectsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetByIdSubjectQuery(int id)
        {
            var query = new GetByIdSubjectQuery(id);
            var academy = await _mediator.Send(query);

            if (academy is null)
            {
                return NotFound();
            }
            return (academy);
        }
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> CreateSubject(CreateSubjectCommand command)
        {
            var academy = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateSubject), new { id = academy.Id }, academy);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject(UpdateSubjectCommand command)
        {
            var subject = await _mediator.Send(command);

            if (subject is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _mediator.Send(new DeleteSubjectCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
