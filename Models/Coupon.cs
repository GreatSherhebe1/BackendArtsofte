using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Coupon
{
    public long Couponid { get; set; }

    public string Promocode { get; set; } = null!;

    public DateOnly Validfrom { get; set; }

    public DateOnly Validto { get; set; }

    public int? Maxuses { get; set; }

    public long Userid { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
