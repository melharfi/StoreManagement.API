using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.API.DTOs
{
    public class DeleteBrand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
