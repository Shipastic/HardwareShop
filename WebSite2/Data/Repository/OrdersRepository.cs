using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;

namespace WebSite2.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly CatalogContext catalogContext;

        private readonly ShopProduct shopProduct;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="catalogContext"></param>
        /// <param name="shopProduct"></param>
        public OrdersRepository(CatalogContext catalogContext, ShopProduct shopProduct)
        {
            this.catalogContext = catalogContext;
            this.shopProduct = shopProduct;
        }
        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;

            //Добавить заказ в таблицу БД
            catalogContext.Orders.Add(order);

            var items = shopProduct.ListshopItems;

            foreach (var element in items)
            {
                var orderDetail = new OrderDetail()
                {
                    
                    ProductId = element.Product.ProductId,
                    OrderId = order.OrderId,
                    Price = element.Product.Price
                };
                catalogContext.OrderDetails.Add(orderDetail);
                
            }
            catalogContext.SaveChangesAsync();
        }
    }
}
