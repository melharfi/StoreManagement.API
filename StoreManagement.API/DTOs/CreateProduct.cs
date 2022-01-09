using System;
using System.ComponentModel.DataAnnotations;

namespace StoreManagement.API.DTOs
{
    public class CreateProduct
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid BrandId { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
