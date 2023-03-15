using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Room
{
    public long Id { get; set; }

    public long? StateId { get; set; }

    public long? HotelId { get; set; }

    public string? Name { get; set; }

    public long? CategotyId { get; set; }

    public virtual ICollection<Arrive> Arrives { get; } = new List<Arrive>();

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Category? Categoty { get; set; }

    public virtual ICollection<Departure> Departures { get; } = new List<Departure>();

    public virtual Hotel? Hotel { get; set; }

    public virtual State? State { get; set; }
}
