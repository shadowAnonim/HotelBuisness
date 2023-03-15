using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class Guest
{
    public long Id { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<ArrivedGuest> ArrivedGuests { get; } = new List<ArrivedGuest>();

    public virtual ICollection<DeparturedGuest> DeparturedGuests { get; } = new List<DeparturedGuest>();
}
