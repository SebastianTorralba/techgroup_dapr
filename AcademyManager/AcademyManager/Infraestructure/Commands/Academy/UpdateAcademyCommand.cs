using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Academy
{
    public record UpdateAcademyCommand(int Id, string Name, string Description, bool Enabled) : IRequest<AcademyDto>;

}
