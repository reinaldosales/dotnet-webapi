using System.ComponentModel.DataAnnotations;

namespace DotnetWebAPI.ViewModels
{
    public class CreateUserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
