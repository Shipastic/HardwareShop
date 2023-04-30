# HardwareShop
### Движок сайта на ASP.NET Core
Данный проект реализует движок сайта по продаже комплектующих частей и периферийного оборудования для ПК.
- В качестве архитектурного паттерна был выбран паттерн MVC(Model - View - Controller).
- Запросы к базе данных выполняются при помощи LINQ to entiies.
- В качестве базы данных используется MS SQL.
- Данные из базы с помощью ORM(Entity Framework Core) помещаются в DTO:
```c#
   public class CatalogRepository : ICatalogGroup
    {
        private CatalogContext catalogContext;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="catalogContext"></param>
        public CatalogRepository(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        public IEnumerable<CatalogGroup> AllCategories => catalogContext.CatalogGroups.Include(c => c.MainCategory);
    }
```
- В запросе LINQ передаются в слой представления для отображения пользователю.
```c#
   public IActionResult ShowMenu()
        {
            IEnumerable<CatalogGroup> catalogs = null;
            IEnumerable<MainCategory> mainCategories = null;
            List<CatalogGroup> catalogs1 = new List<CatalogGroup>();
            mainCategories = _allCategory.MainCategories.OrderBy(c => c.NameCategory);
            foreach (var categ in mainCategories)
            {
                catalogs = _allCatalogGroup.AllCategories.Where(cg => cg.MainCategoryId == categ.MainCategoryId);
                catalogs1.AddRange(catalogs);
            }
            var catObj = new ProductsListViewModel
            {
                MainCatalogGroups = catalogs,
                MainCategories = mainCategories            
            };
            return View(catObj);
        }
```
- Затем выводятся пользователю:
```html
  ﻿@model WebSite2.ViewModels.ProductsListViewModel
<div class="col-lg-3 col-md-4 col-sm-5">
    <div class="accordion">
        @{
            foreach (WebSite2.Data.Models.MainCategory mainCategory in Model.MainCategories)
            {
                <div class="panel closed">
                    <div class="panel-header">
                        <i class="fa fa-bar-chart"></i>
                        @mainCategory.NameCategory
                        <i class="fa fa-angle-right arrow"></i>
                        <span class="spacer"></span>
                    </div>
                    <div class="panel-content">
                        @{ if (mainCategory.CatalogGroups == null)
                                continue;
                            else
                            {
                                foreach (WebSite2.Data.Models.CatalogGroup category in mainCategory.CatalogGroups)
                                    @Html.Partial("AllCategory", category)
                                }
                        }
                    </div>
                </div>
            }
        }
    </div>
</div>
```
