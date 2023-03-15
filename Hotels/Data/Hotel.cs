using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Hotel
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
