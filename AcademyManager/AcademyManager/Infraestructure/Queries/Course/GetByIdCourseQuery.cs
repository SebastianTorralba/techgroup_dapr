using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Course
{
    public record GetByIdCourseQuery(int Id) : IRequest<CourseDto>;

}
