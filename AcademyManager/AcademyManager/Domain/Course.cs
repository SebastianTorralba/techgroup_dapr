namespace AcademyManager.Domain
{
    public class Course : BaseEntity
    {
        public string Section { get; set; }
        public int AcademyId { get; set; }
        public int ClassroomId { get;}
        public int SubjectId { get; set; }
    }
}
