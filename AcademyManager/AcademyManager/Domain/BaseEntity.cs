namespace AcademyManager.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
    }
}
