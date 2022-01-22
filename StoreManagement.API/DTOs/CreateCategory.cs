using System.ComponentModel.DataAnnotations;

namespace StoreManagement.API.DTOs
{
    public class CreateCategory
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
