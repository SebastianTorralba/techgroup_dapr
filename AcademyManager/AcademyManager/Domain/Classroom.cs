namespace AcademyManager.Domain
{
    public class Classroom : BaseEntity
    {
        public Classroom()
        {
            Courses = new HashSet<Course>(); 
        }

        public int Number { get; set; }
        public ICollection<Course> Courses { get; set; } 

    }
}
