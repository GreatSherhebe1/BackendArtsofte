using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Product
{
    public long Productid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public decimal? Price { get; set; }

    public string? Category { get; set; }

    public double? Weight { get; set; }

    public double? Calories { get; set; }

    public virtual ICollection<DiscountsProduct> DiscountsProductProductnameNavigations { get; set; } = new List<DiscountsProduct>();

    public virtual ICollection<DiscountsProduct> DiscountsProductProducts { get; set; } = new List<DiscountsProduct>();

    public virtual ICollection<IngredientsProduct> IngredientsProducts { get; set; } = new List<IngredientsProduct>();

    public virtual ICollection<OrdersProduct> OrdersProductProductnameNavigations { get; set; } = new List<OrdersProduct>();

    public virtual ICollection<OrdersProduct> OrdersProductProducts { get; set; } = new List<OrdersProduct>();
}
