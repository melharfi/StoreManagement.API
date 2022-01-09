using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain
{
    public class CategoryPagination
    {
        public List<Category> Categories { get; set; }
        public int CollectionSize { get; set; }
    }
}
