using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Subject;
using AcademyManager.Infraestructure.Data;
using MediatR;

namespace AcademyManager.Application.Handler.Subject
{
    public class CreateSubjectCommandHamdler : IRequestHandler<CreateSubjectCommand, SubjectDto>
    {
        private readonly DataContext _dataContext;

        public CreateSubjectCommandHamdler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<SubjectDto> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = new Domain.Subject
            {
                Name = request.Name,
                CourseId = request.CourseId,
                AcademyId= request.AcademyId,
                TeacherId= request.TeacherId
            };

            _dataContext.Subjects.Add(subject);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                CourseId = subject.CourseId,
                AcademyId= subject.AcademyId,
                TeacherId= subject.TeacherId,
                Enabled = subject.Enabled
            };
        }
    }
}
