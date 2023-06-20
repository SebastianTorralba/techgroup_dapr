using AcademyManager.Infraestructure.Commands.Teacher;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Teacher
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly DataContext _dataContext;

        public DeleteTeacherCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dataContext.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (teacher is null)
            {
                return false;
            }

            _dataContext.Teachers.Remove(teacher);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
