using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class EmployeesOrder
{
    public long Id { get; set; }

    public long Employeeid { get; set; }

    public long Orderid { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
