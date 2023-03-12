using System;
using System.Collections.Generic;

namespace Pishi_Stiray.Data.Models;

public partial class OrderCompound
{
    public int OrderId { get; set; }

    public string Compound { get; set; } = null!;

    public int Amount { get; set; }
}
