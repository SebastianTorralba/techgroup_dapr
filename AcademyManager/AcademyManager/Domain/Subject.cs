namespace AcademyManager.Domain
{
    public class Subject: BaseEntity
    {
        public string Name { get; set; }
        public int AcademyId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

    }

}
