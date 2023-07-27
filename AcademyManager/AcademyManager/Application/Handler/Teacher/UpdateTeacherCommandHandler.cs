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

            teacher.FirstName = request.FirstName;
            teacher.LastName = request.LastName;
            teacher.Enabled = request.Enabled;
            teacher.UpdatedDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return new TeacherDto
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Enabled = request.Enabled
            };

        }

    }
}
