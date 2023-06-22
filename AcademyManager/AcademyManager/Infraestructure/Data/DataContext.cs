using AcademyManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infraestructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Classroom> Clasrooms { get; set; }
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
