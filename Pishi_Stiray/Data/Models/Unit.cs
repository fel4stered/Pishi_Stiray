using System;
using System.Collections.Generic;

namespace Pishi_Stiray.Data.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string UnitName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
