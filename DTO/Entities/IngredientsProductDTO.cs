using Backend.Models;

namespace Backend.DTO.Entities
{
    public class IngredientsProductDTO
    {
        public long Id { get; set; }

        public double? Amount { get; set; }

        public long Ingredientid { get; set; }

        public long Productid { get; set; }

        public virtual IngredientDTO Ingredient { get; set; } = null!;

        public virtual ProductDTO Product { get; set; } = null!;
    }
}
