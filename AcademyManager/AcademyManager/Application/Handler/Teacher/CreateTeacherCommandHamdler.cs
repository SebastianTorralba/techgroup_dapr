using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Teacher;
using AcademyManager.Infraestructure.Data;
using MediatR;

namespace AcademyManager.Application.Handler.Teacher
{
    public class CreateTeacherCommandHamdler : IRequestHandler<CreateTeacherCommand, TeacherDto>
    {
        private readonly DataContext _dataContext;

        public CreateTeacherCommandHamdler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TeacherDto> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = new Domain.Teacher
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AcademyId= request.AcademyId,
            };

            _dataContext.Teachers.Add(teacher);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Enabled = teacher.Enabled
            };
        }
    }
}
