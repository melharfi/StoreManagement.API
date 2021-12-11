using System;
using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Domain
{
    public class Category : Entity
    {
        public Category() : base()
        {

        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
