using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class DeparturedGuest
{
    public long Id { get; set; }

    public long GuestId { get; set; }

    public long DepartureId { get; set; }

    public virtual Departure Departure { get; set; } = null!;

    public virtual Guest Guest { get; set; } = null!;
}
