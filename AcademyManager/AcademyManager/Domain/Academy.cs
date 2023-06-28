namespace AcademyManager.Domain
{
    public class Academy : BaseEntity
    {
        public Academy()
        {
            Subjects = new HashSet<Subject>();
            Courses = new HashSet<Course>();
            Classrooms = new HashSet<Classroom>();
            //Teachers = new HashSet<Teacher>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Subject>  Subjects { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
        //public ICollection<Teacher> Teachers { get; set; }

    }
}
