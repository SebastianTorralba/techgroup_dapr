using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Subject
{
    public record GetAllSubjectsQuery : IRequest<IEnumerable<SubjectDto>>;

}
