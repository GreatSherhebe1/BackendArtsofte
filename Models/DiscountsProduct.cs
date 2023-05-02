using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class DiscountsProduct
{
    public long Id { get; set; }

    public long Discountid { get; set; }

    public string? Productname { get; set; }

    public long Productid { get; set; }

    public virtual Discount Discount { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Product? ProductnameNavigation { get; set; }
}
