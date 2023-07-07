using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Subject
{
    public record DeleteSubjectCommand(int Id) : IRequest<bool>;

}
