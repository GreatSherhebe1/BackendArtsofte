using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class OrdersProduct
{
    public long Id { get; set; }

    public long Orderid { get; set; }

    public string? Productname { get; set; }

    public long Productid { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Product? ProductnameNavigation { get; set; }
}
