using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Course
{
    public record CreateCourseCommand(string Section, int AcademyId, int ClassroomId) : IRequest<CourseDto>;

}
