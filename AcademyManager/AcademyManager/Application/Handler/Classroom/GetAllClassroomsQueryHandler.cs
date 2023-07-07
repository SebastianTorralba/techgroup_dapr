using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Classroom;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Classroom
{
    public class GetAllClassroomsQueryHandler : IRequestHandler<GetAllClassroomsQuery, IEnumerable<ClassroomDto>>
    {
        private readonly DataContext _dataContext;

        public GetAllClassroomsQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ClassroomDto>> Handle(GetAllClassroomsQuery request, CancellationToken cancellationToken)
        {
            var classroom = await _dataContext.Classrooms
                                .Select(t => new ClassroomDto
                                {
                                    Id = t.Id,
                                    Number = t.Number,
                                    Enabled = t.Enabled
                                })
                                .ToListAsync(cancellationToken);

            return classroom;
        }


    }
}
