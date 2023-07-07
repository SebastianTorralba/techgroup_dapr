using AcademyManager.Infraestructure.Commands.Subject;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Subject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, bool>
    {
        private readonly DataContext _dataContext;

        public DeleteSubjectCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _dataContext.Subjects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (subject is null)
            {
                return false;
            }

            _dataContext.Subjects.Remove(subject);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
