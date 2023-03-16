using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Arrive
{
    public long Id { get; set; }

    public DateTime? Date { get; set; } = null!;

    public long RoomId { get; set; }

    public DateTime? DepartureDate { get; set; } = null!;

    public long? BookingId { get; set; }

    public virtual ICollection<ArrivedGuest> ArrivedGuests { get; } = new List<ArrivedGuest>();

    public virtual Booking? Booking { get; set; }

    public virtual Room Room { get; set; } = null!;
}
