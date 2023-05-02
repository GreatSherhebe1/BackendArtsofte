using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Ingredient
{
    public long Ingredientid { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public virtual ICollection<IngredientsProduct> IngredientsProducts { get; set; } = new List<IngredientsProduct>();
}
