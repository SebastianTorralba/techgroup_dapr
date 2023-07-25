using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Academy;
using AcademyManager.Infraestructure.Data;
using MediatR;

namespace AcademyManager.Application.Handler.Academy
{
    public class CreateAcademyCommandHandler : IRequestHandler<CreateAcademyCommand, AcademyDto>
    {
        private readonly DataContext _dataContext;

        public CreateAcademyCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<AcademyDto> Handle(CreateAcademyCommand request, CancellationToken cancellationToken)
        {
            var academy = new Domain.Academy
            {
                Name = request.Name,
                Description = request.Description,
                
            };

            _dataContext.Academies.Add(academy);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new AcademyDto
            {
                Id = academy.Id,
                Name = academy.Name,
                Description = academy.Description,
                Enabled = academy.Enabled
            };
        }
    }
}
