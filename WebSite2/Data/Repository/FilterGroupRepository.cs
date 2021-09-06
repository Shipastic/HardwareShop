using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;

namespace WebSite2.Data.Repository
{
    public class FilterGroupRepository : IFilterGroup
    {
        private CatalogContext catalogContext;
        public FilterGroupRepository(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        IEnumerable<FilterGroup> IFilterGroup.FilterGroups => catalogContext.FilterGroups;

}
}
