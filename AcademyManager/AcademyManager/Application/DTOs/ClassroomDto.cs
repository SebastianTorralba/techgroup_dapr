namespace AcademyManager.Application.DTOs
{
    public class ClassroomDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Enabled { get; set; }
        public int AcademyId { get; internal set; }
    }
}
