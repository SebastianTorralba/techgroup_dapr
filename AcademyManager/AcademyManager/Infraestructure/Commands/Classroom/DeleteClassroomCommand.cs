using MediatR;

namespace AcademyManager.Infraestructure.Commands.Classroom
{
    public record DeleteClassroomCommand(int Id) : IRequest<bool>;

}
