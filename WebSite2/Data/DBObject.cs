using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.Models;

namespace WebSite2.Data
{
    /// <summary>
    /// Класс инициализирующий БД начальными значениями
    /// </summary>
    public class DBObject
    {
        //Все методы здесь делаем статические
        /// <summary>
        /// Инициализация БД объектами по умолчанию
        /// </summary>
        /// <param name="catalogContext"></param>
        public static void Initial(CatalogContext catalogContext)
        {

            //Если в БД уже есть хотя бы одна запись в таблице CatalogGroup - то ничего не делаем
            //В противном случае из словаря Categories добавляем все значения ключей - Value
            //В таблицу CatalogGroup
            if (!catalogContext.MainCategories.Any())
            {
                catalogContext.MainCategories.AddRange(MainKategories.Select(k => k.Value));
            }

            if (!catalogContext.CatalogGroups.Any())
            {
                catalogContext.CatalogGroups.AddRange(Categories.Select(c => c.Value));
            }

            if (!catalogContext.FilterGroups.Any())
            {
                catalogContext.FilterGroups.AddRange(Groups.Select(g => g.Value));
            }

            if (!catalogContext.FilterNames.Any())
            {
                catalogContext.FilterNames.AddRange(Filters.Select(f => f.Value));
            }
            //if (!catalogContext.FilterNames.Any())
            //{
            //    catalogContext.FilterNames.AddRange(Filters.Select(f => f.Value));
            //}         

            if (!catalogContext.Products.Any())
            {
                catalogContext.Products.AddRange(Tovars.Select(t => t.Value));
            }


            if (!catalogContext.PropertyValues.Any())
            {
                catalogContext.PropertyValues.AddRange(PropValues.Select(pv => pv.Value));
            }
                   
           //Сохранить все изменения в БД
            catalogContext.SaveChanges();

            
        }

         
        private static Dictionary<string, MainCategory> mainKategory;

        /// <summary>
        /// Метод для инициализации Категорий при создании БД
        /// </summary>
        public static Dictionary<string, MainCategory> MainKategories
        {
            get
            {
                if (mainKategory == null)
                {
                    //Создаем массив объектов типа CatalogGroup
                    var list = new MainCategory[]
                    {
                     new MainCategory { NameCategory = "Комплектующие"             },
                     new MainCategory { NameCategory = "Периферийное оборудование" },
                     new MainCategory { NameCategory = "Ноутбуки И ПК"             },
                     new MainCategory { NameCategory = "Оргтехника и зап.части"    }
                    };

                    mainKategory = new Dictionary<string, MainCategory>();

                    //В цикле перебираем массив list и добавляем в словарь новый объект
                    //ключ - GroupName, значение - объект group(Value)
                    foreach (MainCategory group in list)
                    {
                        mainKategory.Add(group.NameCategory, group);
                    }
                }
                return mainKategory;
            }
        }


        private static Dictionary<string, CatalogGroup> category;
       
        /// <summary>
        /// Метод для инициализации Категорий при создании БД
        /// </summary>
        public static Dictionary<string, CatalogGroup> Categories
        {
            get
            {
                if (category == null)
                {
                    //Создаем массив объектов типа CatalogGroup
                    var list = new CatalogGroup[]
                    {
                     new CatalogGroup { GroupName = "Материнские платы", Note = "Подборка материнских плат",                MainCategory = mainKategory["Комплектующие"]             },
                     new CatalogGroup { GroupName = "Процессоры",        Note = "Подборка процессоров" ,                    MainCategory = mainKategory["Комплектующие"]             },
                     new CatalogGroup { GroupName = "Видеокарты",        Note = "Подборка видеокарт"  ,                     MainCategory = mainKategory["Комплектующие"]             },
                     new CatalogGroup { GroupName = "Жесткие диски",     Note = "Подборка жестких дисков" ,                 MainCategory = mainKategory["Комплектующие"]             },
                     new CatalogGroup { GroupName = "Ноутбуки",          Note = "Различные виды ноутбуков" ,                MainCategory = mainKategory["Ноутбуки И ПК"]             },
                     new CatalogGroup { GroupName = "Планшеты",          Note = "Различные виды планшетов" ,                MainCategory = mainKategory["Ноутбуки И ПК"]             },
                     new CatalogGroup { GroupName = "Компьютер/Неттоп",  Note = "Готовые сборки ПК" ,                       MainCategory = mainKategory["Ноутбуки И ПК"]             },
                     new CatalogGroup { GroupName = "Принтер/Плоттер",   Note = "Устройства для печати" ,                   MainCategory = mainKategory["Периферийное оборудование"] },
                     new CatalogGroup { GroupName = "МФУ",               Note = "Многофункциональные устройства" ,          MainCategory = mainKategory["Периферийное оборудование"] },
                     new CatalogGroup { GroupName = "Сканер",            Note = "Устройства для сканирования документов" ,  MainCategory = mainKategory["Периферийное оборудование"] },
                     new CatalogGroup { GroupName = "Картриджи",         Note = "Картриджи для принтеров" ,                 MainCategory = mainKategory["Оргтехника и зап.части"]    }
                    };

                    category = new Dictionary<string, CatalogGroup>();

                    //В цикле перебираем массив list и добавляем в словарь новый объект
                    //ключ - GroupName, значение - объект group(Value)
                    foreach (CatalogGroup group in list)
                    {
                        category.Add(group.GroupName, group);
                    }
                }
            return category;               
            }
        }

        private static Dictionary<string, FilterGroup> group;

        /// <summary>
        /// Метод для инициализации Категорий при создании БД
        /// </summary>
        public static Dictionary<string, FilterGroup> Groups
        {
            get
            {
                if (group == null)
                {
                    //Создаем массив объектов типа CatalogGroup
                    var list = new FilterGroup[]
                    {
                     new FilterGroup {FilterGroupName = "Диапазон цен"                 },
                     new FilterGroup {FilterGroupName = "Выбор поставщиков"            },
                     new FilterGroup {FilterGroupName = "Выбор производителей"         },
                     new FilterGroup {FilterGroupName = "Внешние характеристики товара"},
                     new FilterGroup {FilterGroupName = "Характеристики памяти"        },
                     new FilterGroup {FilterGroupName = "Характеристики экрана"        },
                     new FilterGroup {FilterGroupName = "Поддерживаемые форматы"       },
                     new FilterGroup {FilterGroupName = "Внешние интерфейсы"           },
                     new FilterGroup {FilterGroupName = "Внутренние интерфейсы"        },
                     new FilterGroup {FilterGroupName = "Материал"                     }
                    };

                    group = new Dictionary<string, FilterGroup>();

                    //В цикле перебираем массив list и добавляем в словарь новый объект
                    //ключ - GroupName, значение - объект group(Value)
                    foreach (FilterGroup filterGroup in list)
                    {
                        group.Add(filterGroup.FilterGroupName, filterGroup);
                    }
                }
                return group;
            }
        }

        private static Dictionary<string, FilterName> Filter;

        public static Dictionary<string, FilterName> Filters
        {
            get
            {
                if(Filter == null)
                {
                    var list = new FilterName[]
                    {
                        new FilterName
                        {
                            ValueFilter     = "Price",
                            FilterGroup     = Groups["Диапазон цен"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,                           
                        },
                        new FilterName
                        {
                            ValueFilter     ="Model",
                            FilterGroup     = Groups["Выбор поставщиков"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,
                        },
                        new FilterName
                        {
                            ValueFilter     = "Brand",
                            FilterGroup     = Groups["Выбор производителей"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,
                        },
                        new FilterName
                        {
                            ValueFilter     = "weight",
                            FilterGroup     = Groups["Внешние характеристики товара"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,
                        },
                        new FilterName
                        {
                            ValueFilter     = "Dimensions",
                            FilterGroup     = Groups["Внешние характеристики товара"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,
                        },
                        new FilterName
                        {
                            ValueFilter     = "Объем жесткого диска",
                            FilterGroup     = Groups["Характеристики памяти"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,
                        },
                        new FilterName
                        {
                            ValueFilter     = "Объем SSD",
                            FilterGroup     = Groups["Характеристики памяти"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,
                        },
                        new FilterName
                        {
                            ValueFilter     = "Объем оперативной памяти",
                            FilterGroup     = Groups["Характеристики памяти"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,
                        },
                        new FilterName
                        {
                            ValueFilter     = "Тип матрицы",
                            FilterGroup     = Groups["Характеристики экрана"],
                            CatalogGroup    = Categories["Материнские платы"],
                            Product         = Tovars["Материнская плата ASUS"],
                            DisplayInFilter = true,
                        }
                        //new FilterName
                        //{
                        //    ValueFilter     = "Price",
                        //    FilterGroup     = Groups["Диапазон цен"],
                        //    CatalogGroup    = Categories["Жесткие диски"],
                        //    Product         = Tovars["Жесткий диск SeaGate"],
                        //    DisplayInFilter = true,
                        //},
                        //new FilterName
                        //{
                        //    ValueFilter     ="Model",
                        //    FilterGroup     = Groups["Выбор поставщиков"],
                        //    CatalogGroup    = Categories["Жесткие диски"],
                        //    Product         = Tovars["Жесткий диск SeaGate"],
                        //    DisplayInFilter = true,
                        //},
                        //new FilterName
                        //{
                        //    ValueFilter     = "Brand",
                        //    FilterGroup     = Groups["Выбор производителей"],
                        //    CatalogGroup    = Categories["Жесткие диски"],
                        //    Product         = Tovars["Жесткий диск SeaGate"],
                        //    DisplayInFilter = true,
                        //},
                        // new FilterName
                        //{
                        //    ValueFilter     = "Price",
                        //    FilterGroup     = Groups["Диапазон цен"],
                        //    CatalogGroup    = Categories["Процессоры"],
                        //    Product         = Tovars["процессор INTEL"],
                        //    DisplayInFilter = true,
                        //},
                        //new FilterName
                        //{
                        //    ValueFilter     ="Model",
                        //    FilterGroup     = Groups["Выбор поставщиков"],
                        //    CatalogGroup    = Categories["Процессоры"],
                        //    Product         = Tovars["процессор INTEL"],
                        //    DisplayInFilter = true,
                        //},
                        //new FilterName
                        //{
                        //    ValueFilter     = "Brand",
                        //    FilterGroup     = Groups["Выбор производителей"],
                        //    CatalogGroup    = Categories["Процессоры"],
                        //    Product         = Tovars["процессор INTEL"],
                        //    DisplayInFilter = true,
                        //},
                    };

                    Filter = new Dictionary<string, FilterName>();
                    foreach (FilterName group in list)
                    {
                        Filter.Add(group.ValueFilter, group);
                    }
                }
                return Filter;
            }
        }


        private static Dictionary<string, Product> tovar;

        ///// <summary>
        ///// Метод для инициализации Свойств при создании БД
        ///// </summary>
        public static Dictionary<string, Product> Tovars
        {
            get
            {
                if (tovar == null)
                {
                    var list = new Product[]
                    {
                        new Product
                        {
                            ProductName     = "Материнская плата ASUS",
                            Available       = true,
                            Description     = "Классная материнская плата",
                            LongDescription = "Современная Дорогая Классная материнская плата",
                            ImagePath       = "/img/materinskaja-plata.png",
                            Price           = 10000,
                            CatalogGroup    = Categories["Материнские платы"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "процессор INTEL",
                            Available       = true,
                            Description     = "Лучший процессор в своей категории",
                            LongDescription = "Современный Дорогой Мощный процессор",
                            ImagePath       = "/img/CPU.png",
                            Price           = 30000,
                            CatalogGroup    = Categories["Процессоры"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "Видеокарта NVIDIA  GeForce 3080",
                            Available       = true,
                            ImagePath       = "/img/videokarta.png",
                            Description     = "Мощнейшая видеокарта",
                            LongDescription = "Современная Дорогая Классная Быстрая Видеокарта",
                            Price           = 100000,
                            CatalogGroup    = Categories["Видеокарты"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "Жесткий диск SeaGate",
                            Available       = true,
                            Description     = "Шустрый жесткий диск",
                            LongDescription = "Быстрый Дорогой Надежный Жесткий диск",
                            ImagePath       = "/img/HDD.png",
                            Price           = 10000,
                            CatalogGroup    = Categories["Жесткие диски"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "SSD диск Toshiba",
                            Available       = true,
                            Description     = "Недорогой твердотельный накопитель",
                            LongDescription = "Сверхбыстрый Дорогой Компактный ССД",
                            ImagePath       = "/img/HDD.png",
                            Price           = 15000,
                            CatalogGroup    = Categories["Жесткие диски"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "Ноутбук HP 15 Series",
                            Available       = true,
                            Description     = "Недорогой ноутбук",
                            LongDescription = "Мощный недорогой Компактный ноутбук",
                            ImagePath       = "/img/notebook.png",
                            Price           = 35000,
                            CatalogGroup    = Categories["Ноутбуки"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "МФУ",
                            Available       = true,
                            Description     = "Многофункциональное устройство",
                            LongDescription = "Печать цветных изображений и документов",
                            ImagePath       = "/img/MFU.png",
                            Price           = 20000,
                            CatalogGroup    = Categories["МФУ"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "Принтер Epson",
                            Available       = true,
                            Description     = "Печать документов",
                            LongDescription = "Цветная струйная бизнес-печать",
                            ImagePath       = "/img/printer.png",
                            Price           = 15000,
                            CatalogGroup    = Categories["Принтер/Плоттер"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "Сканер Canon",
                            Available       = true,
                            Description     = "Планшетный",
                            LongDescription = "Сканирование документов А4",
                            ImagePath       = "/img/scaner.png",
                            Price           = 10000,
                            CatalogGroup    = Categories["Сканер"],
                            Supplier        = 1
                        },
                        new Product
                        {
                            ProductName     = "Картридж CACTUS",
                            Available       = true,
                            Description     = "Для лазерных принтеров",
                            LongDescription = "Аналог оригинального картриджа",
                            ImagePath       = "/img/kartridg.png",
                            Price           = 5000,
                            CatalogGroup    = Categories["Картриджи"],
                            Supplier        = 1
                        }
                    };

                    tovar = new Dictionary<string, Product>();

                    //Перебираем все записи из словаря Properties, записанные в массив list
                    //И записываем в словарь property: где PropertyName - ключ, экземпляр класса со всеми полями - значение(Value)
                    foreach (Product tov in list)
                    {
                        tovar.Add(tov.ProductName, tov);
                    }
                }
                return tovar;
            }  
        }

        private static Dictionary<string, PropertyValue> propvalue;

        /// <summary>
        /// Метод для инициализации Категорий при создании БД
        /// </summary>
        public static Dictionary<string, PropertyValue> PropValues
        {
            get
            {
                if (propvalue == null)
                {
                    //Создаем массив объектов типа CatalogGroup
                    var list = new PropertyValue[]
                    {
                     new PropertyValue{ Value = "H310CM-DVS",   FilterName = Filters["Model"]                    },
                     new PropertyValue{ Value = "H310CM-S2",    FilterName = Filters["Model"]                    },
                     new PropertyValue{ Value = "H310CM-S2 1.1",FilterName = Filters["Model"]                    },
                     new PropertyValue{ Value = "ASUS",         FilterName = Filters["Model"]                    },
                     new PropertyValue{ Value = "ASRock",       FilterName = Filters["Model"]                    },
                     new PropertyValue{ Value = "ProBook",      FilterName = Filters["Model"]                    },
                     new PropertyValue{ Value = "HP",           FilterName = Filters["Model"]                    },
                     new PropertyValue{ Value = "5000",         FilterName = Filters["Price"]                    },
                     new PropertyValue{ Value = "0.7 kg",       FilterName = Filters["weight"]                   },
                     new PropertyValue{ Value = "0.4 kg",       FilterName = Filters["weight"]                   },
                     new PropertyValue{ Value = "CS-TK1200",    FilterName = Filters["Model"]                    },
                     new PropertyValue{ Value = "8 Gb",         FilterName = Filters["Объем оперативной памяти"] },
                     new PropertyValue{ Value = "16 Gb",        FilterName = Filters["Объем оперативной памяти"] },
                     new PropertyValue{ Value = "256 Gb",       FilterName = Filters["Объем SSD"]                },
                     new PropertyValue{ Value = "512 Gb",       FilterName = Filters["Объем SSD"]                },
                     new PropertyValue{ Value = "IPS",          FilterName = Filters["Тип матрицы"]              }
                    };

                    propvalue = new Dictionary<string, PropertyValue>();

                    //В цикле перебираем массив list и добавляем в словарь новый объект
                    //ключ - GroupName, значение - объект group(Value)
                    foreach (PropertyValue group in list)
                    {
                        propvalue.Add(group.Value, group);
                    }
                }
                return propvalue;
            }
        }
    }
}
