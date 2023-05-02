using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Discount
{
    public long Discountid { get; set; }

    public DateOnly Validfrom { get; set; }

    public DateOnly Validto { get; set; }

    public decimal? Discount1 { get; set; }

    public string? Condition { get; set; }

    public virtual ICollection<DiscountsOrder> DiscountsOrders { get; set; } = new List<DiscountsOrder>();

    public virtual ICollection<DiscountsProduct> DiscountsProducts { get; set; } = new List<DiscountsProduct>();
}
