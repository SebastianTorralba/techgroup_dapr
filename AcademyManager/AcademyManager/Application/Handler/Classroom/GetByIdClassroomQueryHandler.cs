using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Data;
using AcademyManager.Infraestructure.Queries.Academy;
using AcademyManager.Infraestructure.Queries.Classroom;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Classroom
{
    public class GetByIdClassroomQueryHandler : IRequestHandler<GetByIdClassroomQuery, ClassroomDto>
    {
        private readonly DataContext _dataContext;

        public GetByIdClassroomQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ClassroomDto> Handle(GetByIdClassroomQuery request, CancellationToken cancellationToken)
        {
            var classroom = await _dataContext.Classrooms
                                .Select(t => new ClassroomDto
                                {
                                    Id = t.Id,
                                    Number = t.Number,
                                    Enabled = t.Enabled
                                })
                                .FirstOrDefaultAsync(t => t.Id == request.Id);

            if (classroom is null)
            {
                return null;
            }


            return classroom;
        }
    }
}
