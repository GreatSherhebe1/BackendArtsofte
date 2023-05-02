using Backend.Models;

namespace Backend.DTO.Entities
{
    public class IngredientDTO
    {
        public long Ingredientid { get; set; }

        public string Name { get; set; } = null!;

        public decimal? Price { get; set; }

        public virtual ICollection<IngredientsProductDTO> IngredientsProducts { get; set; } = new List<IngredientsProductDTO>();
    }
}
