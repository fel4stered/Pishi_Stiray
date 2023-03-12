﻿using System;
using System.Collections.Generic;

namespace Pishi_Stiray.Data.Models;

public partial class Pname
{
    public int PnameId { get; set; }

    public string ProductName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
