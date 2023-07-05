using AcademyManager.Infraestructure.Commands.Course;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Course
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly DataContext _dataContext;

        public DeleteCourseCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _dataContext.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (course is null)
            {
                return false;
            }

            _dataContext.Courses.Remove(course);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
