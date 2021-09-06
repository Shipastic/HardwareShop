using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.Models
{
   /// <summary>
   ///Класс Значение свойства
   /// </summary>
    public class PropertyValue
    {
        public int PropertyValueId { get; set; }

        //Значение свойства
        public string Value { get; set; }

        //Внешний ключ на FilterName
        public int FilterNameId { get; set; }

        //Навигационное свойство для внешнего ключа
        public virtual FilterName FilterName { get; set; }
        
    }
}
