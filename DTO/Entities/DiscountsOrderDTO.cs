using Backend.Models;

namespace Backend.DTO.Entities
{
    public class DiscountsOrderDTO
    {
        public long Id { get; set; }

        public long Discountid { get; set; }

        public long Orderid { get; set; }

        public virtual DiscountDTO Discount { get; set; } = null!;

        public virtual OrderDTO Order { get; set; } = null!;
    }
}
