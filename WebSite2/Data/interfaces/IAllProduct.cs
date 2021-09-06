using WebSite2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.interfaces
{
  /// <summary>
  /// Интерфейс Товар
  /// </summary>
    public interface IAllProduct {

        /// <summary>
        /// Перечислит все товары из модели Product
        /// </summary>
        IEnumerable<Product> Products { get; }

        /// <summary>
        /// Отобразит популярные товары
        /// </summary>
        IEnumerable<Product> GetFavProducts { get; }

        /// <summary>
        /// Отображает товар по его Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetObjectProduct(int productId); 

    }
}
