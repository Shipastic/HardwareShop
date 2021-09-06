using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.Models
{
    /// <summary>
    /// Класс описывающий всю корзину в целом
    /// </summary>
    public class ShopProduct
    {

        public string ShopProductId { get; set; }

        //Необходимо подключать для работы с БД
        private CatalogContext catalogContext;
        public ShopProduct(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }       
       
        /// <summary>
        /// Список всех элементов отображаемых в корзине
        /// </summary>
        public List<ShopProductItem> ListshopItems { get; set; }

        /// <summary>
        /// Метод проверки существования корзины внутри сессии
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ShopProduct GetProduct(IServiceProvider services)
        {
            //Данный класс нужен для работы с сессиями
            //Создаем новую сессию
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<CatalogContext>();

            //В данную переменную помещаем ID корзины, если корзины не было, то создаем новый Ид через Guid
            string shopProductId = session.GetString("ProdId") ?? Guid.NewGuid().ToString();

            //Устанавливаем значение сессии, в качестве ключа - ProdId, в качестве значения - Guid
            session.SetString("ProdId", shopProductId);

            return new ShopProduct(context) { ShopProductId = shopProductId };
        }

        /// <summary>
        /// Метод добавления товаров в корзину
        /// </summary>
        /// <param name="product"></param>
        public void AddToProduct(Product product)
        {
            catalogContext.ShopProductItems.Add
                (
                    new ShopProductItem
                    {
                        ShopProductId = ShopProductId,
                        Product = product,
                        Price = product.Price
                    }
                );
            catalogContext.SaveChanges();
        }

       /// <summary>
       /// Метод отображения всех товаров в корзине
       /// </summary>
       /// <returns></returns>
        public List<ShopProductItem> GetShopItems()
        {
            return catalogContext.ShopProductItems
                                                    .Where(c => c.ShopProductId == ShopProductId)
                                                    .Include(s => s.Product)
                                                    .ToList();
        }
    }
}
