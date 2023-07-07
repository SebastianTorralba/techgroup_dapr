using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Course;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Course
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly DataContext _dataContext;

        public GetAllCoursesQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _dataContext.Courses
                                .Select(t => new CourseDto
                                {
                                    Id = t.Id,
                                    Section = t.Section,
                                    AcademyId= t.AcademyId,
                                    ClassroomId= t.ClassroomId,
                                    Enabled = t.Enabled,
                                })
                                .ToListAsync(cancellationToken);

            return courses;
        }


    }
}
