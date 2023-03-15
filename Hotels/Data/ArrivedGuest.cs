using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class ArrivedGuest
{
    public long Id { get; set; }

    public long? ArrivalId { get; set; }

    public long? GusetId { get; set; }

    public virtual Arrive? Arrival { get; set; }

    public virtual Guest? Guset { get; set; }
}
