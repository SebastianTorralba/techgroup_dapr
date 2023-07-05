using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Classroom
{
    public record GetAllClassroomsQuery : IRequest<IEnumerable<ClassroomDto>>;

}
