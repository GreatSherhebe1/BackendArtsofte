using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class IngredientsProduct
{
    public long Id { get; set; }

    public double? Amount { get; set; }

    public long Ingredientid { get; set; }

    public long Productid { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
