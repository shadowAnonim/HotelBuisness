using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Hotel
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? RegionId { get; set; }

    public virtual Region? Region { get; set; }

    public virtual ICollection<RoomPrice> RoomPrices { get; } = new List<RoomPrice>();

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
