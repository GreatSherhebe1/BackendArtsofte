using Backend.Models;

namespace Backend.DTO.Entities
{
    public class OrdersProductDTO
    {
        public long Id { get; set; }

        public long Orderid { get; set; }

        public string? Productname { get; set; }

        public long Productid { get; set; }

        public virtual OrderDTO Order { get; set; } = null!;

        public virtual ProductDTO Product { get; set; } = null!;

        public virtual ProductDTO? ProductnameNavigation { get; set; }
    }
}
