using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Employee
{
    public long Employeeid { get; set; }

    public string Fullname { get; set; } = null!;
    
    public DateOnly Birthdate { get; set; }

    public string Address { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public DateOnly Firstworkdate { get; set; }

    public DateOnly? Lastworkdate { get; set; }

    public virtual ICollection<ChecksEmployee> ChecksEmployees { get; set; } = new List<ChecksEmployee>();

    public virtual ICollection<EmployeesOrder> EmployeesOrders { get; set; } = new List<EmployeesOrder>();
}
