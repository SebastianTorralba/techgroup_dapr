using AcademyManager.Infraestructure.Commands.Academy;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Academy
{
    public class DeleteAcademyCommandHandler : IRequestHandler<DeleteAcademyCommand, bool>
    {
        private readonly DataContext _dataContext;

        public DeleteAcademyCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Handle(DeleteAcademyCommand request, CancellationToken cancellationToken)
        {
            var academy = await _dataContext.Academies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (academy is null)
            {
                return false;
            }

            _dataContext.Academies.Remove(academy);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
