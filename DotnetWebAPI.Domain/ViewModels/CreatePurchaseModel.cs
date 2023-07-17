using System.ComponentModel.DataAnnotations;

namespace DotnetWebAPI.ViewModels
{
    public class CreatePurchaseModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}
