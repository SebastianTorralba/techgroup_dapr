using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Course
{
    public record UpdateCourseCommand(int Id, string Section, int AcademyId, int ClassroomId, bool Enabled) : IRequest<CourseDto>;

}
