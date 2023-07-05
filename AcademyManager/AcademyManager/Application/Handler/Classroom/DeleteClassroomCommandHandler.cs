
using AcademyManager.Infraestructure.Commands.Classroom;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Classroom
{
    public class DeleteClassroomCommandHandler : IRequestHandler<DeleteClassroomCommand, bool>
    {
        private readonly DataContext _dataContext;

        public DeleteClassroomCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
        {
            var classroom = await _dataContext.Classrooms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (classroom is null)
            {
                return false;
            }

            _dataContext.Classrooms.Remove(classroom);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
