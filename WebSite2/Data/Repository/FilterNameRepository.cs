using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;

namespace WebSite2.Data.Repository
{
    public class FilterNameRepository : IAllFilterName
    {
        private CatalogContext catalogContext;

        IEnumerable<FilterName> filterNames = null;
       
        IEnumerable<Product> prod = null;

        public FilterNameRepository(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        /// <summary>
        /// Фильтр в зависимости от группы фильтров
        /// </summary>
        public IEnumerable<FilterName> FilterNamesToFilterGroups => catalogContext.FilterNames.Include(n => n.FilterGroup);

        public IEnumerable<FilterName> GetFilterNamesByCatalogGroup => catalogContext.FilterNames.Include(g => g.CatalogGroup);
        /// <summary>
        /// Фильтр в зависимости от от товара
        /// </summary>
        public IEnumerable<FilterName> FilterNames => catalogContext.FilterNames.Include
            (
                n =>
                     from f in filterNames
                     join p in prod on
                     f.ProductId equals p.ProductId
                     select f.ValueFilter
             );

        public FilterName GetFilterName(int filternameid) => catalogContext.FilterNames.FirstOrDefault(p => p.FilterNameId == filternameid);

        public IEnumerable<FilterName> GetNameFilter(int productId) => catalogContext.FilterNames.Where(f => f.ProductId.Equals(productId)).Include(g => g.Product);

        public IEnumerable<FilterGroup> filterGroups => catalogContext.FilterGroups.ToList();

        //Получаем все свойства для продукта
        public IEnumerable<FilterName> ProductProperties => catalogContext.FilterNames.Include(c => c.Product);

        //Получаем все свойства для категории
        public IEnumerable<FilterName> GetProperties => catalogContext.FilterNames.Include(c => c.FilterGroup);

    }
}
