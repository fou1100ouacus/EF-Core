using System;
using System.Collections.Generic;

namespace MigrationEFCore10;

public partial class SectionSchedule
{
    public int Id { get; set; }

    public int SectionId { get; set; }

    public int ScheduleId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual Section Section { get; set; } = null!;
}
