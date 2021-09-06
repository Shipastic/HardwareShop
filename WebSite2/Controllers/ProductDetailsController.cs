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
    public class ProductDetailsController : Controller
    {
        private readonly IAllProduct _allProducts;

        private readonly IAllFilterName _allFilterName;
        public ProductDetailsController(IAllProduct allProd, IAllFilterName allFilterName)
        {
            _allProducts = allProd;

            _allFilterName = allFilterName;
        }

        public IActionResult Detail(string nameprod)
        {
            //IEnumerable<Product> products = null;

            var concreteProduct = _allProducts.Products.Where(p => p.ProductName.Contains(nameprod)).FirstOrDefault();

            var concreteFilters = _allFilterName.GetNameFilter(concreteProduct.ProductId);

            var detailObj = new ProductDetailViewModel
            {
                GetProduct = concreteProduct,

                GetFilterNames = concreteFilters
            };
                return View(detailObj);
        }
    }
}
