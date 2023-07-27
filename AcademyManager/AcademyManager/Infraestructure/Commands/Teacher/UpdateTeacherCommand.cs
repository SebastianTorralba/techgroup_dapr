using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Teacher
{
    public record UpdateTeacherCommand(int Id, string FirstName, string LastName, bool Enabled) : IRequest<TeacherDto>;

}
