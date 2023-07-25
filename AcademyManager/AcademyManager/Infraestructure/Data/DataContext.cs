using AcademyManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infraestructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<Academy> Academies { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academy>(entity =>
            {
                entity.ToTable("Academy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.ToTable("Classroom");

                entity.HasIndex(e => e.AcademyId, "IX_Classroom_AcademyId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.Classroom)
                    .HasForeignKey(d => d.AcademyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.HasIndex(e => e.AcademyId, "IX_Teacher_AcademyId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.AcademyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasIndex(e => e.AcademyId, "IX_Course_AcademyId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.AcademyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.ClassroomId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.HasIndex(e => e.AcademyId, "IX_Subject_AcademyId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.AcademyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
