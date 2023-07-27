using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Teacher;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Teacher
{
    public class GetByIdTeacherQueryHandler : IRequestHandler<GetByIdTeacherQuery, TeacherDto>
    {
        private readonly DataContext _dataContext;

        public GetByIdTeacherQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TeacherDto> Handle(GetByIdTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _dataContext.Teachers
                                .Select(t => new TeacherDto
                                {
                                    Id = t.Id,
                                    FirstName = t.FirstName,
                                    LastName = t.LastName,
                                    Enabled = t.Enabled
                                })
                                .FirstOrDefaultAsync(t => t.Id == request.Id);

            if (teacher is null)
            {
                return null;
            }


            return teacher;
        }
    }
}
