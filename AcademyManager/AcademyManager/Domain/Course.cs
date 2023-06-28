namespace AcademyManager.Domain
{
    public class Course : BaseEntity
    {
        public Course()
        {
            Subjects = new HashSet<Subject>();
        }
        public string Section { get; set; }
        public int AcademyId { get; set; }
        public int ClassroomId { get;}
        public ICollection<Subject> Subjects { get; set; }
    }
}
