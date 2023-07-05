using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Classroom
{
    public record UpdateClassroomCommand(int Id, int Number, int AcademyId, bool Enabled) : IRequest<ClassroomDto>;

}
