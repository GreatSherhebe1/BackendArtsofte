using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class ChecksEmployee
{
    public long Checkid { get; set; }

    public DateOnly Checkdate { get; set; }

    public decimal? Salaryperwork { get; set; }

    public decimal? Taxfee { get; set; }

    public int? Absentdays { get; set; }

    public int? Workdays { get; set; }

    public int? Changedays { get; set; }

    public int? Replacementdays { get; set; }

    public string? Description { get; set; }

    public long Employeeid { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
