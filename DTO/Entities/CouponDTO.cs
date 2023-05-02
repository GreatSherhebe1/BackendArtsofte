using Backend.Models;

namespace Backend.DTO.Entities
{
    public class CouponDTO
    {
        public long Couponid { get; set; }

        public string Promocode { get; set; } = null!;

        public DateOnly Validfrom { get; set; }

        public DateOnly Validto { get; set; }

        public int? Maxuses { get; set; }

        public long Userid { get; set; }

        public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();

        public virtual UserDTO User { get; set; } = null!;
    }
}
