using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Booking
{
    public long Id { get; set; }

    public byte[]? ArrivalDate { get; set; }

    public byte[]? DepartureDate { get; set; }

    public long? RoomId { get; set; }

    public virtual Room? Room { get; set; }
}
