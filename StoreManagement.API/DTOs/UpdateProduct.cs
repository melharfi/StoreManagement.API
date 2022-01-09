using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.API.DTOs
{
    public class UpdateProduct
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
