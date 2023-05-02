using Backend.Models;

namespace Backend.Schema.Mutation
{
    public class OrderInputType
    {
        public decimal Cost { get; set; }

        public string? Address { get; set; }

        public DateOnly Createdate { get; set; }

        public DateOnly Preparationdate { get; set; }

        public DateOnly Completingdate { get; set; }

        public string? Promocode { get; set; }

        public long Userid { get; set; }
    }
}
