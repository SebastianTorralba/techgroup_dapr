using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Course;
using AcademyManager.Infraestructure.Commands.Teacher;
using AcademyManager.Infraestructure.Data;
using MediatR;

namespace AcademyManager.Application.Handler.Course
{
    public class CreateCourseCommandHamdler : IRequestHandler<CreateCourseCommand, CourseDto>
    {
        private readonly DataContext _dataContext;

        public CreateCourseCommandHamdler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Domain.Course
            {
                Section = request.Section,
                ClassroomId = request.ClassroomId,
                AcademyId= request.AcademyId,
            };

            _dataContext.Courses.Add(course);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new CourseDto
            {
                Id = course.Id,
                Section = course.Section,
                AcademyId = course.AcademyId,
                ClassroomId= course.ClassroomId,
                Enabled = course.Enabled
            };
        }
    }
}
