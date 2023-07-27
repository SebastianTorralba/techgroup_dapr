using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Subject;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Subject
{
    public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, IEnumerable<SubjectDto>>
    {
        private readonly DataContext _dataContext;

        public GetAllSubjectsQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<SubjectDto>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            var subject = await _dataContext.Subjects
                                .Select(t => new SubjectDto
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    TeacherId= t.TeacherId,
                                    TeacherName= t.Teacher.FirstName,
                                    AcademyId = t.AcademyId,
                                    CourseId = t.CourseId,
                                    Enabled = t.Enabled
                                })
                                .ToListAsync(cancellationToken);

            return subject;
        }


    }
}
