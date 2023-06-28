using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Academy
{
    public record DeleteAcademyCommand(int Id) : IRequest<bool>;

}
