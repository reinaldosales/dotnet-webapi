using DotnetWebAPI.ObjectValues;

namespace DotnetWebAPI.Models
{
    public class User : Entity.Entity
    {
        protected User() { }

        public User(string name, Email email, DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) : base(createdAt, updatedAt, deletedAt)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }
        public Email Email { get; }
    }
}
