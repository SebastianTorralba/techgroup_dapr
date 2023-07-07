namespace AcademyManager.Application.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CourseId { get; set; }
        public int AcademyId { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = null!;
        public bool Enabled { get; set; }

    }
}
