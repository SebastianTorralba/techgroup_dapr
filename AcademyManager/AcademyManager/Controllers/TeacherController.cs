using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Teacher;
using AcademyManager.Infraestructure.Queries.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TeacherDto>> GetAllTeachers()
        {
            return await _mediator.Send(new GetAllTeachersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetByIdTeacherQuery(int id)
        {
            var query = new GetByIdTeacherQuery(id);
            var teacher = await _mediator.Send(query);

            if (teacher is null)
            {
                return NotFound();
            }
            return (teacher);
        }
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> CreateTecher(CreateTeacherCommand command)
        {
            var teacher = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateTecher), new { id = teacher.Id }, teacher);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherCommand command)
        {
            var teacher = await _mediator.Send(command);

            if (teacher is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _mediator.Send(new DeleteTeacherCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
