using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.Models
{
/// <summary>
/// Класс, отвечающий за конкретный товар в корзине 
/// </summary>
    public class ShopProductItem
    {
        /// <summary>
        /// ID товара
        /// </summary>
        public int Id { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Id товара в корзине
        /// </summary>
        public string ShopProductId { get; set; }
    }
}
