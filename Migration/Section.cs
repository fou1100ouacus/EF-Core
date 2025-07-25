using System;
using System.Collections.Generic;

namespace MigrationEFCore10;

public partial class Section
{
    public int Id { get; set; }

    public string SectionName { get; set; } = null!;

    public int? CourseId { get; set; }

    public int? InstructorId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
