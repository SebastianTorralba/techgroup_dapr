using AcademyManager.Application.DTOs;
using AcademyManager.Domain;
using AcademyManager.Infraestructure.Commands.Course;
using AcademyManager.Infraestructure.Queries.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            return await _mediator.Send(new GetAllCoursesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetByIdCourseQuery(int id)
        {
            var query = new GetByIdCourseQuery(id);
            var course = await _mediator.Send(query);

            if (course is null)
            {
                return NotFound();
            }
            return (course);
        }
        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse(CreateCourseCommand command)
        {
            var course = await _mediator.Send(command);
            return CreatedAtAction(nameof(Course), new { id = course.Id }, course);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommand command)
        {
            var course = await _mediator.Send(command);

            if (course is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _mediator.Send(new DeleteCourseCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
