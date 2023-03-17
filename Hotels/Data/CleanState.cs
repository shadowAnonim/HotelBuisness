using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class CleanState
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Clean> Cleans { get; } = new List<Clean>();
}
