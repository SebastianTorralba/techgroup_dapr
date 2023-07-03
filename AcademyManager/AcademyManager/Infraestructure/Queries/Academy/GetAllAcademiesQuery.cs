using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Academy
{
    public record GetAllAcademiesQuery : IRequest<IEnumerable<AcademyDto>>;

}
