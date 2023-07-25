namespace AcademyManager.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
