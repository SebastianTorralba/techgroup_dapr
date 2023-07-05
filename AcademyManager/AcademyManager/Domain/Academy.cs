namespace AcademyManager.Domain
{
    public class Academy : BaseEntity
    {
        public Academy()
        {
            Subject = new HashSet<Subject>();
            Course = new HashSet<Course>();
            Classroom = new HashSet<Classroom>();
            Teacher = new HashSet<Teacher>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Subject>  Subject { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Classroom> Classroom { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }

    }
}
