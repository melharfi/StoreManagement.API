using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.API.DTOs
{
    public class BrandPagination
    {
        public List<Brand> Brands { get; set; }
        public int CurrentPageIndex { get; set; }
        public int BrandsListLength { get; set; }
    }
}
