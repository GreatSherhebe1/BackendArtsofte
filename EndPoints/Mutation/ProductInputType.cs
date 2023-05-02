namespace Backend.Schema.Mutation
{
    public class ProductInputType
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Picture { get; set; }

        public decimal? Price { get; set; }

        public string? Category { get; set; }

        public double? Weight { get; set; }

        public double? Calories { get; set; }
    }
}
