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
+ Models:
	Содержит описание сущностей(классов) которые хранятся в Базе Данных:
	- Product - описание конкретного товара;
	- CatalogGroup - Каталог товаров по группам(Видеокарты, процессоры и т. п.);
	- ProductProperty - описывает свойство товара (Модель, Производитель, Вес и т. д.);
	- PropertyValue - содержит конкретное значение для каждого свойства ("ASUS", "HP", "5 kg");
	- ShopProductItem ;
	- ShopProduct ;

+ Interfaces:
	Содержит методы для работы с моделями без реализации:
	- Уровень доступа устанавливаем: public interface
	- IEnumerable<НазваниеКласса> Вывести все товары(категории, свойства, значения свойств);
	- НазваниеКласса GetObjectНазваниеКласса (int переменная) - вывести определенное значение(товар, свойство) по его id:
	

+ Mocks:
	Реализация интерфесов и начальное наполнение классов(до использования Entity Framowork)
	В название добавляем в начало - Mock
	- В реализации IEnumerable<НазваниеКласса> создаем экземпляры класса и устанавливаем значения свойств;
	- При создании конкретных экземпляров классов НЕЛЬЗЯ указывать конкретные ID первичного ключа, EF генерирует их сама и это вызовет ошибку;


+ Repository:
	Содержит классы, реализующие интерфейсы, но не содержат конкретных экземпляров классов;

+ Startup.cs:
	В конструкторе получаем строку подключения;
	В методе public void ConfigureServices(IServiceCollection services) подключаем все используемые сервисы:
	-services.AddTransient<Interface, НазваниеКласса>() - Объединяет между собой интерфейс и класс реализующий интерфейс;
	

+ Controllers:
	- Все созданные контроллеры необходимо унаследовать от базового класса Controller(using Microsoft.AspNetCore.Mvc);
	- По соглашению об именовании в название контроллера в конец добавляем - Controller: ИмяСущController;
	Содержит различные методы которые в итоге возвращают тип данных ViewResult - возвращает HTML-страницу;
	HTML-страницы для данного контроллера должны на ходиться в каталоге : Views- НазваниеКонтроллера_БЕЗ добавления Controller;
	
	
+ Views:
	Содержит все HTML-шаблоны;
	- Внутри создаем Каталоги По имени контроллера без добавления Controller на конце:
		-Внутри уже этого каталога добавляем элемент(выбираем представление): 
			- Название представления должно совпадать с названием метода из контроллера, например, В контроллере ProductsController
			создаем метод с именем List, далее в каталоге Views создаем каталог Products, а внутри каталога - Представление с название
			List;
	- Для создания основного шаблона создаем каталог Shared - внутри создаем общие шаблоны:
		- ASP.NET Core -> Вэб -> Макет Razor (_Layout.cshtml - html-основа сайта(header, body, footer));
	- Для создания стартового представления ->  ASP.NET Core -> Вэб -> Запуск Представления Razor(_ViewStart):
		- при вызове в контроллере любого метода перед вызовом HTML-шаблона, будет вызываться _ViewStart, во _ViewStart указываем
		  в какой основной шаблон мы встраиваем дополнительные блоки(Layout = "_Layout");
	- Создаем дополнительный файл, в который импортируем все необходимые модели: Views -добавить - Создать элемент -
		- ASP.NET Core -> Вэб -> Импорт Представлений Razor(_ViewImports) и указываем какие файлы подключать к шаблону
	Шаблон AllProducs - служит для вывода всех товаров
	
	
+ Построение URL: НазваниеСайта/названиеКонтроллера_Без_Controller/НазваниеМетода	- метод ищет в каталоге Views Представление с таким же названием как и метод	

+ ViewModels:
	Создаем дополнительные модели для передачи в HTML-шаблоны
	
+ CatalogContext.cs:
	Служит для создания подключения к БД;
	Наследуется от DbContext;
	В класс DbSet передаем все модели, которые создадутся в БД;
	
+ DBObject.cs:
	Класс, в котором создаются объекты для первоначальной загрузки в БД при ее создании;
	
+ DbSettings.json:
	Хранит строку подключения к БД;
