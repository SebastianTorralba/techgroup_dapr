using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Academy
{
    public record CreateAcademyCommand(string Name, string Description) : IRequest<AcademyDto>;

}
