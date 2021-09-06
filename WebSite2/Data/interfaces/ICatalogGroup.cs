using WebSite2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.interfaces
{
   /// <summary>
   /// Интерфейс Категории товара
   /// </summary>
    public interface ICatalogGroup {

        /// <summary>
        /// Отобразит все категории из модели CatalogGroup
        /// </summary>
        IEnumerable<CatalogGroup> AllCategories { get; } 

    }
}
