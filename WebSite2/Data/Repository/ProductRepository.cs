using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite2.Data.interfaces;

namespace WebSite2.Data.Models
{
   /// <summary>
   /// Класс реализующий интерфейс Товаров
   /// </summary>
    public class ProductRepository : IAllProduct
    {
        // Создаем экземпляр класса подключения к БД
        private readonly CatalogContext catalogContext;

        public ProductRepository(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        
        //Получаем все данные из класса CatalogGroup
        public IEnumerable<Product> Products => catalogContext.Products.Include(c => c.CatalogGroup);

        public IEnumerable<Product> GetFavProducts => catalogContext.Products.Where(p => p.ProductName.Contains("Процессор")).Include(c => c.CatalogGroup);

        //Получаем товар по переданному ID
        public Product GetObjectProduct(int productId) => catalogContext.Products.FirstOrDefault(p => p.ProductId == productId);

        public IEnumerable<CatalogGroup> catalogGroups => catalogContext.CatalogGroups.ToList();
       
    }
}