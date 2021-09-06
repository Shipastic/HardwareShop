using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSite2.Data.Models
{
    /// <summary>
    /// Класс Товар
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }

        //Название товара
        public string ProductName { get; set; }

        //Краткое описание товара
        public string Description { get; set; }

        //Детальное описание товара
        public string LongDescription { get; set; }

        //Цена товара
        public double Price { get; set; }

        //Доступеность для продажи
        public bool Available { get; set; }

        //Путь к изображению товара
        public string ImagePath { get; set; }

        public int CatalogGroupId { get; set; }

        //Навигационное свойство для внешнего ключа CatalogGroupId
        public virtual CatalogGroup CatalogGroup { get; set; }

        public List<FilterName> FilterNames { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        //Внешний ключ для связи с таблицей Поставщики
        public int Supplier { get; set; }
        //public ProductProperty.PropertyType PropertyType { get; set; }
        //public IEnumerable<Product> Products { get; set; }

    }
}