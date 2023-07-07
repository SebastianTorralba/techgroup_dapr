using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Subject
{
    public record CreateSubjectCommand(string Name, int AcademyId, int TeacherId, int CourseId) : IRequest<SubjectDto>;

}
