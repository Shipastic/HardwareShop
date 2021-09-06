using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;
using WebSite2.ViewModels;

namespace WebSite2.Controllers
{
   /// <summary>
   /// Главная страница сайта
   /// </summary>
    public class HomeController : Controller
    {
        private readonly IAllProduct _prodRep;

        private readonly IAllCategory _allCategory;

        private readonly ICatalogGroup _allCatalogGroup;


        public HomeController(IAllProduct prodRep, IAllCategory allCategory, ICatalogGroup catalogGroup)
        {
            _prodRep = prodRep;
            _allCategory = allCategory;
            _allCatalogGroup = catalogGroup;
        }

        /// <summary>
        /// Метод возвращает Html-шаблон с отображением товара у которых GetFavProducts = true
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var homeProds = new HomeViewModel
            {
                prodName = _prodRep.GetFavProducts
            };
            return View(homeProds);
        }
 
    }
}
