using AcademyManager.Application.DTOs;
using AcademyManager.Infraestructure.Commands.Classroom;
using AcademyManager.Infraestructure.Data;
using MediatR;

namespace AcademyManager.Application.Handler.Classroom
{
    public class CreateClassroomCommandHamdler : IRequestHandler<CreateClassroomCommand, ClassroomDto>
    {
        private readonly DataContext _dataContext;

        public CreateClassroomCommandHamdler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ClassroomDto> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            var classroom = new Domain.Classroom
            {
                Number = request.Number,
                AcademyId = request.AcademyId,

            };

            _dataContext.Classrooms.Add(classroom);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new ClassroomDto
            {
                Id = classroom.Id,
                Number = classroom.Number,
                AcademyId=classroom.AcademyId,
                Enabled = classroom.Enabled
            };
        }
    }
}
