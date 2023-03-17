using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Clean
{
    public DateTime? Date { get; set; } = null!;

    public long Id { get; set; }

    public long RoomId { get; set; }

    public long CleanStateId { get; set; }

    public virtual CleanState CleanState { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
