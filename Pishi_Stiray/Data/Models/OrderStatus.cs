using System;
using System.Collections.Generic;

namespace Pishi_Stiray.Data.Models;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Orderuser> Orderusers { get; } = new List<Orderuser>();
}
