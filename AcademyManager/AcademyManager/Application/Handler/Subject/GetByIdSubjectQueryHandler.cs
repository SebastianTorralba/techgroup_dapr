using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Subject;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Subject
{
    public class GetByIdSubjectQueryHandler : IRequestHandler<GetByIdSubjectQuery, SubjectDto>
    {
        private readonly DataContext _dataContext;

        public GetByIdSubjectQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<SubjectDto> Handle(GetByIdSubjectQuery request, CancellationToken cancellationToken)
        {
            var subject = await _dataContext.Subjects
                                .Select(t => new SubjectDto
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    TeacherId = t.TeacherId,
                                    TeacherName = t.Teacher.FirstName,
                                    AcademyId = t.AcademyId,
                                    CourseId = t.CourseId,
                                    Enabled = t.Enabled
                                })
                                .FirstOrDefaultAsync(t => t.Id == request.Id);

            if (subject is null)
            {
                return null;
            }


            return subject;
        }
    }
}
