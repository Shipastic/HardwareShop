using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite2.Data.Models
{
    /// <summary>
    /// /Класс категории товаров
    /// </summary>
    public class CatalogGroup
    {
        //Первичный ключ
        public int CatalogGroupId { get; set; }

        //Название категории
        public string GroupName { get; set; }

        //Описание категории
        public string Note { get; set; }

        //Содержит ссылку на товары
        public List<Product> Products { get; set; }

        //Содержит ссылку на свойства товаров
        public List<FilterName> FilterNames { get; set; }

        public virtual MainCategory MainCategory { get; set; }

        public int MainCategoryId { get; set; }
    }
}