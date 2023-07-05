namespace AcademyManager.Domain
{
    public class Course : BaseEntity
    {
        public Course()
        {
            Subject = new HashSet<Subject>();
        }
        public string Section { get; set; }
        public int AcademyId { get; set; }
        public int ClassroomId { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }

        public virtual Academy Academy { get; set; } = null!;
        public virtual Classroom Classroom { get; set; } = null!;
    }
}
