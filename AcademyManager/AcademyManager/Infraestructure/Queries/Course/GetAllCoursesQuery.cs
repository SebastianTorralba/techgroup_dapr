using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Course
{
    public record GetAllCoursesQuery : IRequest<IEnumerable<CourseDto>>;

}
