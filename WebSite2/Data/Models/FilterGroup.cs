using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.Models
{
    /// <summary>
    /// Группировка фильтра по категориям товара
    /// </summary>
    public class FilterGroup
    {
        public int FilterGroupId { get; set; }

        public string FilterGroupName { get; set; }

        public List<FilterName> FilterNames { get; set; }
    }
}
