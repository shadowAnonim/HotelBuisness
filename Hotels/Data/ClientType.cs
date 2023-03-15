using System;
using System.Collections.Generic;

namespace Hotels.Data;

public partial class ClientType
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
