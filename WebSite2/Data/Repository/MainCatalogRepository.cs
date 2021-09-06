using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;

namespace WebSite2.Data.Repository
{
    public class MainCatalogRepository : IAllCategory
    {
        private CatalogContext catalogContext;
        public MainCatalogRepository(CatalogContext _catalogContext)
        {
            catalogContext = _catalogContext;
        }

        public IEnumerable<MainCategory> MainCategories => catalogContext.MainCategories;

    }
}
