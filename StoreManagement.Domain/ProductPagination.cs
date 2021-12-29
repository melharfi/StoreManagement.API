using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain
{
    public class ProductPagination
    {
        public List<Product> Products { get; set; }
        public int CollectionSize { get; set; }
    }
}
