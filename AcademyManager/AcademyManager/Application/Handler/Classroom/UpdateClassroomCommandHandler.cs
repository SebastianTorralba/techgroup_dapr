using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Academy;
using AcademyManager.Infraestructure.Commands.Classroom;
using AcademyManager.Infraestructure.Commands.Teacher;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Classroom
{
    public class UpdateClassroomCommandHandler : IRequestHandler<UpdateClassroomCommand, ClassroomDto>
    {
        private readonly DataContext _dataContext;

        public UpdateClassroomCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ClassroomDto> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            var classroom = await _dataContext.Classrooms.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (classroom is null)
            {
                return null;
            }

            classroom.Number = request.Number;
            classroom.AcademyId = request.AcademyId;
            classroom.Enabled = request.Enabled;
            classroom.UpdatedDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return new ClassroomDto
            {
                Id = request.Id,
                Number = request.Number,
                Enabled = request.Enabled
            };

        }

    }
}
