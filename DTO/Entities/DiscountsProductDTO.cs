using Backend.Models;

namespace Backend.DTO.Entities
{
    public class DiscountsProductDTO
    {
        public long Id { get; set; }

        public long Discountid { get; set; }

        public string? Productname { get; set; }

        public long Productid { get; set; }

        public virtual DiscountDTO Discount { get; set; } = null!;

        public virtual ProductDTO Product { get; set; } = null!;

        public virtual ProductDTO? ProductnameNavigation { get; set; }
    }
}
