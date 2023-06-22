using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Teacher
{
    public record GetAllTeachersQuery : IRequest<IEnumerable<TeacherDto>>;

}
