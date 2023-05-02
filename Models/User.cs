using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models;

namespace Backend;

public partial class User
{
    public long Userid { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string Phone { get; set; } = null!;

    public DateOnly? Birth { get; set; }

    public string? Email { get; set; }

    public long? Gamepoints { get; set; }

    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
