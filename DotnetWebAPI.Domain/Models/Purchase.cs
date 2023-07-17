namespace DotnetWebAPI.Models
{
    public class Purchase : Entity.Entity
    {
        protected Purchase() { }

        public Purchase(decimal value, User user, DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) : base(createdAt, updatedAt, deletedAt)
        {
            Value = value;
            User = user;
        }

        public decimal Value { get; set; }
        public User User { get; set; }
    }
}
