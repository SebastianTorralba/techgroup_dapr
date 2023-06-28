using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Academy
{
    public record GetByIdAcademyQuery(int Id) : IRequest<AcademyDto>;

}
