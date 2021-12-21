using System.ComponentModel.DataAnnotations;

namespace StoreManagement.API.DTOs
{
    public class CreateProduct
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
