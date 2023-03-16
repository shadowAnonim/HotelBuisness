using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Direction
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Discount { get; set; }

    public virtual ICollection<Hotel> Hotels { get; } = new List<Hotel>();
}
