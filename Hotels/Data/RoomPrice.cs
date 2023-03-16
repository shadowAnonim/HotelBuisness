using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class RoomPrice
{
    public long Id { get; set; }

    public long HotelId { get; set; }

    public DateTime? Date { get; set; } = null!;

    public long CategoryId { get; set; }

    public decimal? Price { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;
}
