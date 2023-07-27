using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Teacher;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Teacher
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, IEnumerable<TeacherDto>>
    {
        private readonly DataContext _dataContext;

        public GetAllTeachersQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TeacherDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _dataContext.Teachers
                                .Select(t => new TeacherDto
                                {
                                    Id = t.Id,
                                    FirstName = t.FirstName,
                                    LastName = t.LastName,
                                    Enabled = t.Enabled
                                })
                                .ToListAsync(cancellationToken);

            return teachers;
        }


    }
}
