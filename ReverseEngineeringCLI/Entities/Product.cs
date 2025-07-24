﻿using System;
using System.Collections.Generic;

namespace ReverseEngineeringCLI.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
