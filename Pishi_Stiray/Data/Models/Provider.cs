using System;
using System.Collections.Generic;

namespace Pishi_Stiray.Data.Models;

public partial class Provider
{
    public int Id { get; set; }

    public string ProviderName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
