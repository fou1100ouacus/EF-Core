using System;
using System.Collections.Generic;

namespace MigrationEFCore10;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
