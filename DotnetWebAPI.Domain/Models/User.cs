using DotnetWebAPI.ObjectValues;

namespace DotnetWebAPI.Models
{
    public class User : Entity.Entity
    {
        protected User() { }

        public User(string name, Email email, string role, DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) : base(createdAt, updatedAt, deletedAt)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public string Name { get; }
        public Email Email { get; }
        public string Role{ get; set; }
    }
}
