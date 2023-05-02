using Backend.Models;

namespace Backend.DTO.Entities
{
    public class ProductDTO
    {
        public long Productid { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Picture { get; set; }

        public decimal? Price { get; set; }

        public string? Category { get; set; }

        public double? Weight { get; set; }

        public double? Calories { get; set; }

        public virtual ICollection<DiscountsProductDTO> DiscountsProductProductnameNavigations { get; set; } = new List<DiscountsProductDTO>();

        public virtual ICollection<DiscountsProductDTO> DiscountsProductProducts { get; set; } = new List<DiscountsProductDTO>();

        public virtual ICollection<IngredientsProductDTO> IngredientsProducts { get; set; } = new List<IngredientsProductDTO>();

        public virtual ICollection<OrdersProductDTO> OrdersProductProductnameNavigations { get; set; } = new List<OrdersProductDTO>();

        public virtual ICollection<OrdersProductDTO> OrdersProductProducts { get; set; } = new List<OrdersProductDTO>();
    }
}
