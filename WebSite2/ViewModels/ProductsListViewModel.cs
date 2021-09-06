using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.Models;

namespace WebSite2.ViewModels
{
    public class ProductsListViewModel
    {
        //Получает все товары
        public IEnumerable<Product> GetProducts { get; set; }
        public string currCategory { get; set; }

        //public IEnumerable<CatalogGroup> CatalogGroups { get; set; }
        public string nameProduct { get; set; }
        public SelectList CatalogGroups { get; set; }

        public SelectList Categories { get; set; }

        public SelectList ProductsAll { get; set; }

        /// <summary>
        /// Получить выбранный товар
        /// </summary>
        public string currProduct { get; set; }
        public IEnumerable<FilterName> GetFilters { get; set; }
        public IEnumerable<MainCategory> MainCategories { get; set; }
        public IEnumerable<CatalogGroup> MainCatalogGroups { get; set; }

        public IEnumerable<FilterName> ProductProperties { get; set; }
    }
}
