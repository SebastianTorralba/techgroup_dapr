using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Classroom
{
    public record GetByIdClassroomQuery(int Id) : IRequest<ClassroomDto>;

}
