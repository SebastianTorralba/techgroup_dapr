using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Classroom;
using AcademyManager.Infraestructure.Queries.Classroom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClassroomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassroomDto>> GetAllClassrooms()
        {
            return await _mediator.Send(new GetAllClassroomsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassroomDto>> GetByIdClassroomQuery(int id)
        {
            var query = new GetByIdClassroomQuery(id);
            var classroom = await _mediator.Send(query);

            if (classroom is null)
            {
                return NotFound();
            }
            return (classroom);
        }
        [HttpPost]
        public async Task<ActionResult<ClassroomDto>> CreateClassroom(CreateClassroomCommand command)
        {
            var classroom = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateClassroom), new { id = classroom.Id }, classroom);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClassroom(UpdateClassroomCommand command)
        {
            var classroom = await _mediator.Send(command);

            if (classroom is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var result = await _mediator.Send(new DeleteClassroomCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
