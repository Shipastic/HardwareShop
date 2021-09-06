using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;

namespace WebSite2.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;

        private readonly ShopProduct shopProduct;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="catalogContext"></param>
        /// <param name="shopProduct"></param>
        public OrderController(IAllOrders allOrders, ShopProduct shopProduct)
        {
            this.allOrders = allOrders;
            this.shopProduct = shopProduct;
        }

        //Возвращает View, HTML-шаблон, но внутри этого шаблона будут действия пользователя, поэтому IACtionResult
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopProduct.ListshopItems = shopProduct.GetShopItems();
            if(shopProduct.ListshopItems.Count == 0)
            {
                //Для вывода ошибки пользователю - класс ModelState
                ModelState.AddModelError("", "Пустая Корзина!!!");
            }
            //Если все поля на форме заказа заполнены верно и корзина не пуста
            if(ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                //Переходим на другую страницу и вызываем метод Complete
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
