using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class DeadSeason
{
    public byte[] StartDate { get; set; } = null!;

    public byte[] EndDate { get; set; } = null!;

    public long Id { get; set; }

    public long HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
