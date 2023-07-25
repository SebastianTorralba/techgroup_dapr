using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Academy;
using AcademyManager.Infraestructure.Commands.Teacher;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Academy
{
    public class UpdateAcademyCommandHandler : IRequestHandler<UpdateAcademyCommand, AcademyDto>
    {
        private readonly DataContext _dataContext;

        public UpdateAcademyCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<AcademyDto> Handle(UpdateAcademyCommand request, CancellationToken cancellationToken)
        {
            var academy = await _dataContext.Academies.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (academy is null)
            {
                return null;
            }

            academy.Name = request.Name;
            academy.Description = academy.Description;
            academy.Enabled = request.Enabled;
            academy.UpdatedDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return new AcademyDto
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Enabled = request.Enabled
            };

        }

    }
}
