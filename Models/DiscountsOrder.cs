using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class DiscountsOrder
{
    public long Id { get; set; }

    public long Discountid { get; set; }

    public long Orderid { get; set; }

    public virtual Discount Discount { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
