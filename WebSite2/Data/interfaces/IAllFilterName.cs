using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.Models;

namespace WebSite2.Data.interfaces
{
   public interface IAllFilterName
    {
        /// <summary>
        /// получение коллекции фильтров по группе фильтров
        /// </summary>
        IEnumerable<FilterName> FilterNamesToFilterGroups { get; }

        IEnumerable<FilterName> GetFilterNamesByCatalogGroup { get; }

        /// <summary>
        /// получение коллекции фильтров по ид товара
        /// </summary>
        public IEnumerable<FilterName> GetNameFilter(int productId);
    }
}
