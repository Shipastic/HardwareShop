using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.Models;

namespace WebSite2.Data.interfaces
{
 
    /// <summary>
    /// Интерфейс Значение свойств
    /// </summary>
    public interface IValue
    {
        /// <summary>
        /// Перечисление всех значений свойств
        /// </summary>
        IEnumerable<PropertyValue> PropertyValues { get; }
        
        /// <summary>
        /// Ненужный метод - удалить
        /// </summary>
        IEnumerable<PropertyValue> GetFavProducts { get; } 
       
        /// <summary>
        /// Метод возвращающий значение конкретного свойства по ИД
        /// </summary>
        /// <param name="propertyValueId"></param>
        /// <returns></returns>
        PropertyValue GetObjectValue(int propertyValueId);

    }
}
