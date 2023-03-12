﻿using System;
using System.Collections.Generic;

namespace Pishi_Stiray.Data.Models;

public partial class Pmanufacturer
{
    public int PmanufacturerId { get; set; }

    public string ProductManufacturer { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
