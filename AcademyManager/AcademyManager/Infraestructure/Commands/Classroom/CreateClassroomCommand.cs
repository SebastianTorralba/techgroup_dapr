using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Commands.Classroom
{
    public record CreateClassroomCommand(int Number, int AcademyId) : IRequest<ClassroomDto>;

}
