using Backend.Models;

namespace Backend.DTO.Entities
{
    public class UserDTO
    {
        public long Userid { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string Phone { get; set; } = null!;

        public DateOnly? Birth { get; set; }

        public string? Email { get; set; }

        public long? Gamepoints { get; set; }

        public virtual ICollection<CouponDTO> Coupons { get; set; } = new List<CouponDTO>();

        public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
