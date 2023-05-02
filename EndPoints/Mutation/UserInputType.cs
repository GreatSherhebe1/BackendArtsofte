namespace Backend.Schema.Mutation
{
    public class UserInputType
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string Phone { get; set; } = null!;

        public DateOnly? Birth { get; set; }

        public string? Email { get; set; }

        public long? Gamepoints { get; set; }
    }
}
