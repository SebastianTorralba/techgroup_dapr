using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Course;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Course
{
    public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQuery, CourseDto>
    {
        private readonly DataContext _dataContext;

        public GetByIdCourseQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CourseDto> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _dataContext.Courses
                                .Select(t => new CourseDto
                                {
                                    Id = t.Id,
                                    Section = t.Section,
                                    AcademyId = t.AcademyId,
                                    ClassroomId = t.ClassroomId,
                                    Enabled = t.Enabled,
                                })
                                .FirstOrDefaultAsync(t => t.Id == request.Id);

            if (course is null)
            {
                return null;
            }


            return course;
        }
    }
}
