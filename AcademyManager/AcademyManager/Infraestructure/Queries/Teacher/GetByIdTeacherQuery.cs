using AcademyManager.Application.DTOs;
using MediatR;

namespace AcademyManager.Infraestructure.Queries.Teacher
{
    public record GetByIdTeacherQuery(int Id) : IRequest<TeacherDto>;

}
