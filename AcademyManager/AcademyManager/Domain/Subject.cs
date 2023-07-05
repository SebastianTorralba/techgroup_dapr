using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Domain
{
    public class Subject: BaseEntity
    {
        public string Name { get; set; }
        public int AcademyId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        public virtual Academy Academy { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
        //public virtual Classroom Classroom { get; set; } = null!;
    }

}
