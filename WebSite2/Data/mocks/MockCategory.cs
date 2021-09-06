//using WebSite2.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebSite2.Data.interfaces;

//namespace WebSite2.Data.mocks {
//    /// <summary>
//    /// Реализация интерфейса ICatalogGroup
//    /// </summary>
//    public class MockCategory : ICatalogGroup {
//        public IEnumerable<CatalogGroup> AllCategories {
//            get {
//                var catalogGroup = new List<CatalogGroup>
//                {
//                new CatalogGroup
//                {
//                 CatalogGroupId = 1,
//                 GroupName = "Материнские платы",
//                 Note = "Подборка материнских плат",
//                },
//                new CatalogGroup
//                {
//                CatalogGroupId = 2,
//                GroupName = "Процессоры",
//                Note = "Подборка процессоров",
//                },
//                new CatalogGroup
//                {
//                CatalogGroupId = 3,
//                 GroupName = "Видеокарты",
//                 Note = "Подборка видеокарт",
//                },
//                new CatalogGroup
//                {
//                CatalogGroupId = 4,
//                GroupName = "Жесткие диски",
//                Note = "Подборка жестких дисков",
//                },               
//            };
//            return catalogGroup;
//        }
//        }
//    }
//}
