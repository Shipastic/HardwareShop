using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;
using WebSite2.ViewModels;

namespace WebSite2.Controllers
{
    public class ShopProductController : Controller
    {
        private readonly IAllProduct _prodRep;

        private readonly ShopProduct _shopProd;

        public ShopProductController(IAllProduct prodRep, ShopProduct shopProduct)
        {
            _prodRep = prodRep;
            _shopProd = shopProduct;
        }

        public ViewResult Index()
        {
            var items = _shopProd.GetShopItems();

            _shopProd.ListshopItems = items;

            var obj = new ShopProdViewModel
            {
                shopProduct = _shopProd
            };
            return View(obj);
        }

        public RedirectToActionResult addToProd(int id) 
        {
            var item = _prodRep.Products.FirstOrDefault(i => i.ProductId == id);

            if(item != null)
            {
                _shopProd.AddToProduct(item);
            }
            return RedirectToAction("Index");
        }
    }
}
