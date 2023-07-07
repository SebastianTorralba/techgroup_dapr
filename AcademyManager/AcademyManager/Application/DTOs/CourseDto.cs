namespace AcademyManager.Application.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Section { get; set; } = null!;
        public int AcademyId { get; set; }
        public int ClassroomId { get; set; }
        public bool Enabled { get; set; }
    }
}
