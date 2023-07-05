using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Course
{
    public record DeleteCourseCommand(int Id) : IRequest<bool>;

}
