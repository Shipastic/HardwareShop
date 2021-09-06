using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;
using WebSite2.ViewModels;

namespace WebSite2.Controllers
{
    public class ProductsController : Controller
    {

        //Создаем поля типа данных Interface
        //Благодаря сервису AddTransient в Startup.cs мы можем использовать переменные типа интерфейса как переменные типа класса
        private readonly IAllCategory _allCategory;

        private readonly IAllProduct _allProducts;

        private readonly ICatalogGroup _allCatalogGroup;

        private readonly IAllFilterName _allFilterName;

        private readonly IValue _allValue;

        private  CatalogContext _catalogContext;

        //Создаем Конструктор и передаем в качестве параметра интерфейсы и, благодаря связыванию с классом, идет передача и класса, связанного с этим интерфейсом
        // Поэтому передаем и все объекты классов
        public ProductsController(IAllProduct allProd,IAllCategory allCategory, ICatalogGroup catGroup, IValue allVal, CatalogContext catalogContext, IAllFilterName allFilterName)
        {
            _allCategory = allCategory;

            _allProducts = allProd;

            _allCatalogGroup = catGroup;

            _allValue = allVal;

            _catalogContext = catalogContext;

            _allFilterName = allFilterName;
        }
       
        //==============================================================================================================================
        // Метод возвращает список  товаров  по категориям в виде HTML-страницы
        // этот метод срабатывает при переходе по следующим адресам
        [Route("Products/ProductList")]
        [Route("Products/ProductList/{category}")]      
        public ViewResult ProductList(string category)
        {
            //Передача данных внутрь HTML-шаблона через ViewBag
            ViewBag.Title = "Страница с товаром";

            string _category = category;

            //Передаем все товары
            IEnumerable<Product> products = null;

            //Передаем все свойства
            IEnumerable<FilterName> prodProp = null ;

            string currCategory = "";

            //Если мы не выбрали категорию
            if (string.IsNullOrEmpty(category))
            {
                products = _allProducts.Products.OrderBy(i => i.ProductId);
                prodProp = _allFilterName.FilterNamesToFilterGroups.OrderBy(f => f.CatalogGroup.GroupName == category);  
            }
            else
            {
                if (string.Equals("Процессоры", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Процессоры")).OrderBy(i => i.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                    if (string.Equals("Видеокарты", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Видеокарты")).OrderBy(i => i.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                        if (string.Equals("Жесткие диски", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Жесткие диски")).OrderBy(i => i.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Материнские платы")).OrderBy(i => i.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                    
                        if (string.Equals("Ноутбуки", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Ноутбуки")).OrderBy(p => p.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                        if (string.Equals("Планшеты", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Планшеты")).OrderBy(p => p.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                        if (string.Equals("Компьютер/Неттоп", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Компьютер/Неттоп")).OrderBy(p => p.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                        if (string.Equals("Принтер/Плоттер", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Принтер/Плоттер")).OrderBy(p => p.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                        if (string.Equals("МФУ", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("МФУ")).OrderBy(p => p.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                        if (string.Equals("Сканер", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Сканер")).OrderBy(p => p.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
                else
                        if (string.Equals("Картриджи", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Картриджи")).OrderBy(p => p.ProductId);
                    prodProp = _allFilterName.FilterNamesToFilterGroups.Where(f => f.Product.Equals(products));
                }
            }
            var prodObj = new ProductsListViewModel
            {
                GetProducts = products,
                currCategory = _category,
                GetFilters = prodProp,
                ProductProperties = prodProp
            };

            //Передаем полученный объект в шаблон ProductList
            return View(prodObj);
        }

        //==============================================================================================================================
        //public IActionResult ProductList(string catalog, string category)
        //{

        //    string _catalog = catalog;

        //    string _category = category;

        //    IEnumerable<Product> productsList = null;


        //    return View(prodObj);
        //}
        //==============================================================================================================================
        [Route("Products/ProductListView")]
        [Route("Products/ProductListView/{category}")]
        public IActionResult ProductListView(string nameProductSearch, string groups)
        {

            ViewData["PRODUCTNAME"] = nameProductSearch;
            ViewData["GROUPS"] = groups;

            IEnumerable<Product> products = null;

            IEnumerable<CatalogGroup> catalogs = null;

            string _category = groups;

            products = _catalogContext.Products.Include(c => c.CatalogGroup);

            var prods = from p in products
                        select p;

            //Если задано название товара, то поиск по названию товара
            if (!string.IsNullOrEmpty(nameProductSearch) )
            {
                prods = _allProducts.Products.Where(s => s.ProductName == ViewData["PRODUCTNAME"].ToString());
                catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName == ViewData["GROUPS"].ToString());
            }
            else
                //Если не задано ни название товара, ни каталог, то отображаем все товары
                if (nameProductSearch == null && groups == null)
                {
                    prods = _allProducts.Products.OrderBy(p => p.ProductId);
                    catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName == groups);
                }
                else   
                    //Если не задано название товара
                    if (string.IsNullOrEmpty(nameProductSearch))
                    {
                    //Отображаем все товары в соответствии с выбранной группой
                        
                        if (string.Equals("Материнские платы", groups, StringComparison.OrdinalIgnoreCase))
                        {
                            prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Материнские платы")).OrderBy(p => p.ProductId);
                            catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if(string.Equals("Процессоры", groups, StringComparison.OrdinalIgnoreCase))
                        {
                            prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Процессоры")).OrderBy(p => p.ProductId);
                            catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if(string.Equals("Видеокарты", groups, StringComparison.OrdinalIgnoreCase))
                        {
                            prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Видеокарты")).OrderBy(p => p.ProductId);
                            catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if(string.Equals("Жесткие диски", groups, StringComparison.OrdinalIgnoreCase))
                        {
                        prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Жесткие диски")).OrderBy(p => p.ProductId);
                        catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if (string.Equals("Ноутбуки", groups, StringComparison.OrdinalIgnoreCase))
                        {
                        prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Ноутбуки")).OrderBy(p => p.ProductId);
                        catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if (string.Equals("Планшеты", groups, StringComparison.OrdinalIgnoreCase))
                        {
                        prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Планшеты")).OrderBy(p => p.ProductId);
                        catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if (string.Equals("Компьютер/Неттоп", groups, StringComparison.OrdinalIgnoreCase))
                        {
                        prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Компьютер/Неттоп")).OrderBy(p => p.ProductId);
                        catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if (string.Equals("Принтер/Плоттер", groups, StringComparison.OrdinalIgnoreCase))
                        {
                        prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Принтер/Плоттер")).OrderBy(p => p.ProductId);
                        catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if (string.Equals("МФУ", groups, StringComparison.OrdinalIgnoreCase))
                        {
                        prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("МФУ")).OrderBy(p => p.ProductId);
                        catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if (string.Equals("Сканер", groups, StringComparison.OrdinalIgnoreCase))
                        {
                        prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Сканер")).OrderBy(p => p.ProductId);
                        catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }
                        else
                        if (string.Equals("Картриджи", groups, StringComparison.OrdinalIgnoreCase))
                        {
                        prods = _allProducts.Products.Where(i => i.CatalogGroup.GroupName.Equals("Картриджи")).OrderBy(p => p.ProductId);
                        catalogs = _allCatalogGroup.AllCategories.OrderBy(c => c.GroupName.Equals(groups));
                        }       
                }           
            var prodObj = new ProductsListViewModel
            {
                GetProducts =prods,
                ProductsAll = new SelectList(prods, "ProductName", "ProductName"),
                CatalogGroups = new SelectList(catalogs, "GroupName", "GroupName"),
            };
            return View(prodObj);
        }

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
    }
}
