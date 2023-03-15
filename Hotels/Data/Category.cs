using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Category
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? PeopleCount { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
