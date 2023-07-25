using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Subject;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Subject
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, SubjectDto>
    {
        private readonly DataContext _dataContext;

        public UpdateSubjectCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<SubjectDto> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _dataContext.Subjects.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (subject is null)
            {
                return null;
            }

            subject.Name = request.Name;
            subject.AcademyId = request.AcademyId;
            subject.CourseId = request.CourseId;
            subject.TeacherId = request.TeacherId;
            subject.Enabled = request.Enabled;
            subject.UpdatedDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return new SubjectDto
            {
                Id = request.Id,
                Name = request.Name,
                AcademyId = request.AcademyId,
                CourseId = request.CourseId,
                TeacherId=request.TeacherId,
                Enabled = request.Enabled
            };

        }

    }
}
