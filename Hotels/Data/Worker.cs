using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Worker
{
    public long Id { get; set; }

    public string FullName { get; set; } = null!;

    public long WorkId { get; set; }

    public virtual ICollection<Clean> Cleans { get; } = new List<Clean>();

    public virtual WorkType Work { get; set; } = null!;
}
