using Backend.Models;

namespace Backend.DTO.Entities
{
    public class DiscountDTO
    {
        public long Discountid { get; set; }

        public DateOnly Validfrom { get; set; }

        public DateOnly Validto { get; set; }

        public decimal? Discount1 { get; set; }

        public string? Condition { get; set; }

        public virtual ICollection<DiscountsOrderDTO> DiscountsOrders { get; set; } = new List<DiscountsOrderDTO>();

        public virtual ICollection<DiscountsProductDTO> DiscountsProducts { get; set; } = new List<DiscountsProductDTO>();
    }
}
