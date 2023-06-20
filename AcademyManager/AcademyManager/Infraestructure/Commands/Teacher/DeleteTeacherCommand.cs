using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Teacher
{
    public record DeleteTeacherCommand(int Id) : IRequest<bool>;

}
