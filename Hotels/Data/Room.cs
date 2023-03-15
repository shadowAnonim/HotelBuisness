using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Room
{
    public long Id { get; set; }

    public byte[]? Booked { get; set; }

    public long? StateId { get; set; }

    public long? HotelId { get; set; }

    public byte[]? Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Hotel? Hotel { get; set; }

    public virtual State? State { get; set; }
}
