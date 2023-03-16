using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class DeadSeason
{
    public DateTime? StartDate { get; set; } = null!;

    public DateTime? EndDate { get; set; } = null!;

    public long Id { get; set; }

    public long HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
