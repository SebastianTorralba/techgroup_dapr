using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Teacher
{
    public record CreateTeacherCommand(string FirstName, string LastName, int AcademyId) : IRequest<TeacherDto>;

}
