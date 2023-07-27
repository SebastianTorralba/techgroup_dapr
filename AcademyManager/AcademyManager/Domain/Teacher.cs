namespace AcademyManager.Domain
{
    public class Teacher: BaseEntity
    {
        public Teacher()
        {
            Subject = new HashSet<Subject>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AcademyId { get; set; }
        public virtual Academy Academy { get; set; } = null!;
        public virtual ICollection<Subject> Subject { get; set; } 

    }
}
