using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain
{
    public class Product : Entity
    {
        public Product() : base()
        {

        }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        
    }
}
