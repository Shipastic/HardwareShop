//using WebSite2.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebSite2.Data.interfaces;

//namespace WebSite2.Data.mocks
//{
//    public class MockProducts : IAllProduct {

//          Создаем экземпляр класса MockCategory и приводим его к типу интерфейса ICatalogGroup, через него можно обращаться к свойствам класса MockCategory
//          затем обращаемся к методу AllCategories класса и из него через LINQ берем первый элемент
//        private readonly ICatalogGroup _cattalogGroups = new  MockCategory();

//        public IEnumerable<Product> Products {
//            get {
//                    var product = new List<Product>
//                    {
//                    new Product
//                    {
//                    ProductId = 1,
//                    ProductName = "Материнская плата ASUS",
//                    Available = true,
//                    Description = "Классная материнская плата",
//                    LongDescription = "Современная Дорогая Классная материнская плата",
//                    ImagePath = "/img/materinskaja-plata.png",
//                    Price = 20000,
//                    CatalogGroupId = 1,
//                    CatalogGroup = _cattalogGroups.AllCategories.First(),
//                    },
//                    new Product
//                    {
//                    ProductId = 2,
//                    ProductName = "процессор INTEL",
//                    Available = true,
//                    Description = "Лучший процессор в своей категории",
//                    LongDescription = "Современный Дорогой Мощный процессор",
//                    ImagePath = "/img/CPU.png",
//                    Price = 30000,
//                    CatalogGroupId = 2,
//                    CatalogGroup = _cattalogGroups.AllCategories.First(),
//                    },
//                    new Product
//                    {
//                    ProductId = 3,
//                    ProductName = "Видеокарта NVIDIA  GeForce 3080",
//                    Available = true,
//                    ImagePath = "/img/videokarta.png",
//                    Description = "Мощнейшая видеокарта",
//                    LongDescription = "Современная Дорогая Классная Быстрая Видеокарта",
//                    Price = 100000,
//                    CatalogGroupId = 3,
//                    CatalogGroup = _cattalogGroups.AllCategories.First(),
//                    },
//                   new Product
//                    {
//                    ProductId = 4,
//                    ProductName = "Жесткий диск SeaGate",
//                    Available = true,
//                    Description = "Шустрый жесткий диск",
//                    LongDescription = "Быстрый Дорогой Надежный Жесткий диск",
//                    ImagePath = "/img/HDD.png",
//                    Price = 18000,
//                    CatalogGroupId = 4,
//                    CatalogGroup = _cattalogGroups.AllCategories.Last(),
//                    },
//                    new Product
//                    {
//                    ProductId = 5,
//                    ProductName = "SSD диск Toshiba",
//                    Available = true,
//                    Description = "Недорогой твердотельный накопитель",
//                    LongDescription = "Сверхбыстрый Дорогой Компактный ССД",
//                    ImagePath = "/img/HDD.png",
//                    Price = 25000,
//                    CatalogGroupId = 4,
//                    CatalogGroup = _cattalogGroups.AllCategories.Last(),
//                    },
//                    };
//                return product;
//            }
//        }
//        public IEnumerable<Product> GetFavProducts { get; set; }

//        public Product GetObjectProduct(int productId) {
//            throw new NotImplementedException();
//        }
//    }
//}
