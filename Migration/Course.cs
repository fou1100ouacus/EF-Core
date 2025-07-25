using System;
using System.Collections.Generic;

namespace MigrationEFCore10;

public partial class Course
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
