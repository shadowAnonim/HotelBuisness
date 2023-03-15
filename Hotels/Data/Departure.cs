using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Departure
{
    public long Id { get; set; }

    public DateTime? Date { get; set; } = null!;

    public long RoomId { get; set; }

    public long? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Room Room { get; set; } = null!;
}
