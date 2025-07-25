using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MigrationEFCore10;

public partial class MetigatorAcademyContext : DbContext
{
    public MetigatorAcademyContext()
    {
    }

    public MetigatorAcademyContext(DbContextOptions<MetigatorAcademyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SectionSchedule> SectionSchedules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = MetigatorAcademy ; Integrated Security = SSPI; TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC0755FA43A5");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instruct__3214EC07C60CC125");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Office).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Instructo__Offic__3B75D760");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Offices__3214EC07C614CF32");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OfficeLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OfficeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3214EC07B6CD2009");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Fri).HasColumnName("FRI");
            entity.Property(e => e.Mon).HasColumnName("MON");
            entity.Property(e => e.Sat).HasColumnName("SAT");
            entity.Property(e => e.Sun).HasColumnName("SUN");
            entity.Property(e => e.Thu).HasColumnName("THU");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tue).HasColumnName("TUE");
            entity.Property(e => e.Wed).HasColumnName("WED");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sections__3214EC07C1F9A3ED");

            entity.HasIndex(e => e.CourseId, "idx_sections_course_id");

            entity.HasIndex(e => e.InstructorId, "idx_sections_instructor_id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SectionName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Sections__Course__3E52440B");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Sections)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Sections__Instru__3F466844");
        });

        modelBuilder.Entity<SectionSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SectionS__3214EC07BEF980A6");

            entity.HasIndex(e => e.ScheduleId, "idx_section_schedules_schedule_id");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Schedule).WithMany(p => p.SectionSchedules)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SectionSc__Sched__44FF419A");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionSchedules)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SectionSc__Secti__440B1D61");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07F98B1C75");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasMany(d => d.Sections).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "Enrollment",
                    r => r.HasOne<Section>().WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Enrollmen__Secti__4AB81AF0"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Enrollmen__Stude__49C3F6B7"),
                    j =>
                    {
                        j.HasKey("StudentId", "SectionId").HasName("PK__Enrollme__0ACBDB1E387E83EF");
                        j.ToTable("Enrollments");
                        j.HasIndex(new[] { "SectionId" }, "idx_enrollments_section_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
