using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite2.Data.interfaces;

namespace WebSite2.Data.Models
{
    /// <summary>
    /// Класс реализующий интерфейс Категории товаров
    /// </summary>
    public class CatalogRepository : ICatalogGroup
    {
        private CatalogContext catalogContext;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="catalogContext"></param>
        public CatalogRepository(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        public IEnumerable<CatalogGroup> AllCategories => catalogContext.CatalogGroups.Include(c => c.MainCategory);
    }
}