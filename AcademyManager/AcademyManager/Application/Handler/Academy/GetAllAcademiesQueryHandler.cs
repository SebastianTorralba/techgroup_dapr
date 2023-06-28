using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Academy;
using AcademyManager.Infraestructure.Queries.Teacher;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Academy
{
    public class GetAllAcademiesQueryHandler : IRequestHandler<GetAllAcademiesQuery, IEnumerable<AcademyDto>>
    {
        private readonly DataContext _dataContext;

        public GetAllAcademiesQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<AcademyDto>> Handle(GetAllAcademiesQuery request, CancellationToken cancellationToken)
        {
            var academies = await _dataContext.Academies
                                .Select(t => new AcademyDto
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Description = t.Description,
                                    //Enabled = t.Enabled
                                })
                                .ToListAsync(cancellationToken);

            return academies;
        }


    }
}
