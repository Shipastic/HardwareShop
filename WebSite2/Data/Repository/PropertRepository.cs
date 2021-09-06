//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebSite2.Data.interfaces;
//using WebSite2.Data.Models;

//namespace WebSite2.Data.Repository
//{
//    /// <summary>
//    /// Класс реализующий интерфейс Название Свойств
//    /// </summary>
//    public class PropertRepository : IProperty
//    {
//        private CatalogContext catalogContext;
//        public PropertRepository(CatalogContext catalogContext)
//        {
//            this.catalogContext = catalogContext;
//        }
        
//        //Получаем все свойства для продукта
//        public IEnumerable<ProductProperty> ProductProperties => catalogContext.ProductProperties.Include(c => c.Product);

//        //Получаем все свойства для категории
//        public IEnumerable<ProductProperty> Properties => catalogContext.ProductProperties.Include(c => c.CatalogGroup);

//        public IEnumerable<ProductProperty> GetProperties => catalogContext.ProductProperties.Include(c => c.FilterName);
//    }
//}
