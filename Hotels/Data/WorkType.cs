using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class WorkType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
