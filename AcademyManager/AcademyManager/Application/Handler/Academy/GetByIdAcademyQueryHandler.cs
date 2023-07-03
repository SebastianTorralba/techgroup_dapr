using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Academy;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Academy
{
    public class GetByIdAcademyQueryHandler : IRequestHandler<GetByIdAcademyQuery, AcademyDto>
    {
        private readonly DataContext _dataContext;

        public GetByIdAcademyQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<AcademyDto> Handle(GetByIdAcademyQuery request, CancellationToken cancellationToken)
        {
            var academy = await _dataContext.Academies
                                .Select(t => new AcademyDto
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Description = t.Description,
                                    //Enabled = t.Enabled
                                })
                                .FirstOrDefaultAsync(t => t.Id == request.Id);

            if (academy is null)
            {
                return null;
            }


            return academy;
        }
    }
}
