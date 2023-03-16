using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Hotel
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long RegionId { get; set; }

    public long DirectionId { get; set; }

    public virtual ICollection<DeadSeason> DeadSeasons { get; } = new List<DeadSeason>();

    public virtual Direction Direction { get; set; } = null!;

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<RoomPrice> RoomPrices { get; } = new List<RoomPrice>();

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
