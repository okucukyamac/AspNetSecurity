using System;
using System.Collections.Generic;

namespace DataProtection.web.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double? Price { get; set; }

    public string Color { get; set; } = null!;

    public int CategoriId { get; set; }

}


