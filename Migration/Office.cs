using System;
using System.Collections.Generic;

namespace MigrationEFCore10;

public partial class Office
{
    public int Id { get; set; }

    public string OfficeName { get; set; } = null!;

    public string OfficeLocation { get; set; } = null!;

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
