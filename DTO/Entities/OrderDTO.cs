using Backend.Models;

namespace Backend.DTO.Entities
{
    public class OrderDTO
    {
        public long Orderid { get; set; }

        public decimal Cost { get; set; }

        public string? Address { get; set; }

        public DateOnly Createdate { get; set; }

        public DateOnly Preparationdate { get; set; }

        public DateOnly Completingdate { get; set; }

        public string? Promocode { get; set; }

        public long Userid { get; set; }

        public virtual ICollection<DiscountsOrderDTO> DiscountsOrders { get; set; } = new List<DiscountsOrderDTO>();

        public virtual ICollection<EmployeesOrderDTO> EmployeesOrders { get; set; } = new List<EmployeesOrderDTO>();

        public virtual ICollection<OrdersProductDTO> OrdersProducts { get; set; } = new List<OrdersProductDTO>();

        public virtual CouponDTO? PromocodeNavigation { get; set; }

        public virtual UserDTO User { get; set; } = null!;
    }
}
