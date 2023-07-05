namespace AcademyManager.Domain
{
    public class Classroom : BaseEntity
    {
        public Classroom()
        {
            Course = new HashSet<Course>(); 
        }

        public int Number { get; set; }
        public int AcademyId { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual Academy Academy { get; set; } = null!;
    }
}
