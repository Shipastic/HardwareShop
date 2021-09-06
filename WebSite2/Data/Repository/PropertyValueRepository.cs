using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;

namespace WebSite2.Data.Repository
{
    /// <summary>
    /// Класс реализующий интерфейс Значение свойств
    /// </summary>
    public class PropertyValueRepository : IValue
    {
        private readonly CatalogContext catalogContext;

        public PropertyValueRepository(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        public IEnumerable<PropertyValue> PropertyValues => catalogContext.PropertyValues.Include(c => c.FilterName);
        
        public IEnumerable<PropertyValue> GetFavProducts => catalogContext.PropertyValues.Where(p => p.Value.Equals("ASUS")).Include(c => c.FilterName);

        public PropertyValue GetObjectValue(int propertyValueId) => catalogContext.PropertyValues.FirstOrDefault(p => p.PropertyValueId == propertyValueId);

    }
}
