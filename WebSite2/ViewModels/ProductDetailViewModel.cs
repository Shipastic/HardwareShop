using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.Models;

namespace WebSite2.ViewModels
{
    public class ProductDetailViewModel
    {
        public IEnumerable<FilterName> GetFilterNames { get; set; }

        public IEnumerable<Product> AllProducts { get; set; }
        public Product GetProduct { get; set; }
    }
}
