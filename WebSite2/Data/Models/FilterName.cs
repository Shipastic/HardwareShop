using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.Models
{
    
    /// <summary>
    /// Название конкретного фильтра
    /// </summary>
    public class FilterName
    {
        public int FilterNameId { get; set; }

        public string ValueFilter { get; set; }

        /// <summary>
        ///Содержит ссылку на список значений для свойства
        /// </summary>
        public List<PropertyValue> PropertyValues { get; set; }

        public int FilterGroupId { get; set; }

        public virtual FilterGroup FilterGroup { get; set; }

        //Внешний ключ для связи с таблицей CatalogGroup
        public int CatalogGroupId { get; set; }

        //Навигационное свойство для внешнего ключа CatalogGroupId
        //[ForeignKey("CatalogGroupId")] 
        public virtual CatalogGroup CatalogGroup { get; set; }

        //Внешний ключ на таблицу Product
        public int? ProductId { get; set; }

        //[ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        //Отображение в умном фильтре
        public bool DisplayInFilter { get; set; }
    }
}
