using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebSite2.Data.Models;

namespace WebSite2.ViewModels
{
    public class SmartFilterViewModel
    {
        //Получает все фильтры
        public IEnumerable<FilterName> GetFilters { get; set; }
        public List<string> CatalogFilters { get; set; }
        public string currCategory { get; set; }

        //public IEnumerable<CatalogGroup> CatalogGroups { get; set; }
        public string nameFilter{ get; set; }
        public SelectList FilterGroups { get; set; }
    }
}
