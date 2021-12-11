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
        public Guid ProductCategoryId { get; set; }
        public Category ProductCategory { get; set; }

        public Guid ProductBrandId { get; set; }
        public Brand ProductBrand { get; set; }
        
    }
}
