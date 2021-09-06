using Microsoft.AspNetCore.Mvc;
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
    public class FilterController : Controller
    {
        private CatalogContext _catalogContext;

        //private readonly IValue _allValue;

        private readonly IAllFilterName _allFilterName;

        private readonly ICatalogGroup _catGroup;

        private readonly IValue _allValue;

        ProductsController productsController;

        private readonly IAllProduct _allProducts;

        public FilterController(IAllProduct allProd, ICatalogGroup catGroup, IValue allVal,IAllFilterName allFilterName, CatalogContext catalogContext) 
        {
            _allProducts = allProd;
            _catGroup = catGroup;
            _allValue = allVal;
            _allFilterName = allFilterName;
            _catalogContext = catalogContext;
        }

        [Route("Filter/SmartFilter")]
        [Route("Filter/SmartFilter/{category}")]
        [HttpGet]  
        
        public IActionResult SmartFilter(/*string nameModel, */string category)
        {
            string _category = category;

            IEnumerable<FilterName> filterNames = null;

            IEnumerable<Product> products = null;

            List<string> filterNames1 = new List<string>();

            filterNames = _allFilterName.FilterNamesToFilterGroups.OrderBy(i => i.FilterNameId);

            products = _allProducts.Products.OrderBy(i => i.ProductId);
            //using (_catalogContext)
            //{
            //    var SumFilter = _catalogContext.FilterNames.Join(_catalogContext.ProductProperties, p => p.FilterNameId, pp => pp.FilterNameId, (p, pp) => new {  NameFilter = p.ValueFilter });
            //}
            var allFilter =
                            from f in filterNames
                            join p in products
                            on f.ProductId equals p.ProductId
                            select f ;


            //var allModel = _allProperty.ProductProperties.Where(x => x.PropertyName.Contains(nameModel)).ToList();
            //if(allModel.Count <= 0)
            //{
            //    return HttpNotFound();
            //}
            foreach (var f in allFilter)
            {
                filterNames1.Add(f.ValueFilter);
            }
            var prodObj = new SmartFilterViewModel
            {
                GetFilters = filterNames,
              //  CatalogFilters = (List<string>)allFilter
            };
        return View(prodObj);           
        }

        //public IActionResult PartSmartFilter(CatalogGroup catalogGroup)
        //{
        //    var products = _allProducts.Products.Take(100);

        //    IEnumerable<FilterName> filterNames = null;

        //    IEnumerable<ProductProperty> productProperties = null;

        //    IEnumerable<Product> prod = null;

        //    filterNames = _allFilterName.FilterNamesToFilterGroups.OrderBy(i => i.FilterNameId);
        //    productProperties = _allProperty.ProductProperties.OrderBy(i => i.ProductPropertyId);
        //    prod = _allProducts.Products.OrderBy(i => i.ProductId);
        //    var allFilter =
        //                from f in filterNames
        //                join pp in productProperties on
        //                f.FilterNameId equals pp.FilterNameId
        //                join p in prod on
        //                pp.ProductId equals p.ProductId
        //                where catalogGroup.CatalogGroupId == p.CatalogGroupId
        //                select new
        //                {
        //                    Value = f.ValueFilter
        //                };

            
        //}
    }
}
