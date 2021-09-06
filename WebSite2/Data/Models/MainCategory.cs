using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.Models
{
    public class MainCategory
    {
        public int MainCategoryId { get; set; }
        public string NameCategory { get; set; }
        public List<CatalogGroup> CatalogGroups { get; set; }

    }
}
