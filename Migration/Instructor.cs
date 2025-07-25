using System;
using System.Collections.Generic;

namespace MigrationEFCore10;

public partial class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int OfficeId { get; set; }

    public virtual Office Office { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
