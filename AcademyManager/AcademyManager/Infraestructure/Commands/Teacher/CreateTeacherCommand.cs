using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Teacher
{
    public record CreateTeacherCommand(string Name, string LastName) : IRequest<TeacherDto>;

}
