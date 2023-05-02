using Backend.DTO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Order
{
    public long Orderid { get; set; }

    public decimal Cost { get; set; }

    public string? Address { get; set; }

    public DateOnly Createdate { get; set; }

    public DateOnly Preparationdate { get; set; }

    public DateOnly Completingdate { get; set; }

    public string? Promocode { get; set; }

    public long Userid { get; set; }

    public virtual ICollection<DiscountsOrder> DiscountsOrders { get; set; } = new List<DiscountsOrder>();

    public virtual ICollection<EmployeesOrder> EmployeesOrders { get; set; } = new List<EmployeesOrder>();

    public virtual ICollection<OrdersProduct> OrdersProducts { get; set; } = new List<OrdersProduct>();

    public virtual Coupon? PromocodeNavigation { get; set; }

    public virtual User User { get; set; } = null!;

}
