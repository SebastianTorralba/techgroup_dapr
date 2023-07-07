using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Subject
{
    public record GetByIdSubjectQuery(int Id) : IRequest<SubjectDto>;

}
