using System;
using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Domain
{
    public class Brand : Entity
    {
        public Brand() : base()
        {

        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
