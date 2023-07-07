using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Subject
{
    public record UpdateSubjectCommand(int Id, string Name, int AcademyId, int CourseId, int TeacherId, bool Enabled) : IRequest<SubjectDto>;

}
