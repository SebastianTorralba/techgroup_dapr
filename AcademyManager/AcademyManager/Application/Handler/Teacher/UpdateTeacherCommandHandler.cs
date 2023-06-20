using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Teacher;
using AcademyManager.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Application.Handler.Teacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, TeacherDto>
    {
        private readonly DataContext _dataContext;

        public UpdateTeacherCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TeacherDto> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dataContext.Teachers.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (teacher is null)
            {
                return null;
            }

            teacher.Name = request.Name;
            teacher.LastName = request.LastName;
            teacher.Enabled = request.Enabled;
            teacher.UpdateDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return new TeacherDto
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                Enabled = request.Enabled
            };

        }

    }
}
