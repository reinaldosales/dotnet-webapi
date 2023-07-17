namespace DotnetWebAPI.Entity
{
    public abstract class Entity
    {
        protected Entity() { }

        protected Entity(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
