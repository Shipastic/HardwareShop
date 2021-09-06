using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.Models;

namespace WebSite2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> prodName { get; set; }
        public IEnumerable<FilterName> GetFilters { get; set; }
        public IEnumerable<MainCategory> Categories { get; set; }
        public IEnumerable<CatalogGroup> CatalogGroups { get; set; }
    }
}
