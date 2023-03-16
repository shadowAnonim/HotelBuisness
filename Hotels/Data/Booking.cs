using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Booking
{
    public long Id { get; set; }

    public byte[] ArrivalDate { get; set; } = null!;

    public byte[] DepartureDate { get; set; } = null!;

    public long RoomId { get; set; }

    public long ClientId { get; set; }

    public byte[] BookingDate { get; set; } = null!;

    public byte[] Total { get; set; } = null!;

    public byte[] Accept { get; set; } = null!;

    public virtual ICollection<Arrive> Arrives { get; } = new List<Arrive>();

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Departure> Departures { get; } = new List<Departure>();

    public virtual Room Room { get; set; } = null!;
}
