using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Course;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Course
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, CourseDto>
    {
        private readonly DataContext _dataContext;

        public UpdateCourseCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _dataContext.Courses.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (course is null)
            {
                return null;
            }

            course.Section = request.Section;
            course.AcademyId = request.AcademyId;
            course.ClassroomId = request.ClassroomId;
            course.UpdatedDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return new CourseDto
            {
                Id = request.Id,
                Section = request.Section,
                AcademyId = request.AcademyId,
                ClassroomId = request.ClassroomId,
                Enabled = request.Enabled
            };

        }

    }
}
