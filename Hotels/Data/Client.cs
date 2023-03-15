using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Client
{
    public long Id { get; set; }

    public string? ClientName { get; set; }

    public long? TypeId { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ClientType? Type { get; set; }
}
