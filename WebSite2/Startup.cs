using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;
using WebSite2.Data;
using WebSite2.Data.Repository;

namespace WebSite2
{
    public class Startup
    {
        
        private IConfigurationRoot _configString;
        
        //Конструктор 
        public Startup(IWebHostEnvironment hostVar)
        {
            _configString = new ConfigurationBuilder().SetBasePath(hostVar.ContentRootPath).AddJsonFile("DbSettings.json").Build();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Добавляем подключение к бд
            services.AddDbContext<CatalogContext>(options => options.UseSqlServer(_configString.GetConnectionString("DefaultConnection")));

            //Добавляем сервис для связывания Интерфеса и класса, его реализующего
            services.AddTransient<IAllProduct,   ProductRepository>      ();
            services.AddTransient<ICatalogGroup, CatalogRepository>      ();
            services.AddTransient<IValue,        PropertyValueRepository>();
            services.AddTransient<IAllOrders,    OrdersRepository>       ();
            services.AddTransient<IAllFilterName,FilterNameRepository>   ();
            services.AddTransient<IFilterGroup,  FilterGroupRepository>  ();
            services.AddTransient<IAllCategory,  MainCatalogRepository>  ();
            services.AddRouting();
            //Добавляем сервисы для работы с сессиями
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Для отображения каждому пользователю своей корзины
            services.AddScoped(sp => ShopProduct.GetProduct(sp));

            //Подключение сервиса - MVC
            services.AddRazorPages(); 

            //Для использования кэша
            services.AddMemoryCache();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            //Настраиваем маршрутизацию
            app.UseEndpoints(endpoints =>
            {
                //маршрут по умолчанию
                endpoints.MapControllerRoute(name:    "default", 
                                             pattern: "{controller=Home}/{action=Index}/{id?}");

                //маршрут для перехода по категориям
                endpoints.MapControllerRoute(name:    "categoryFilter", 
                                             pattern: "Products/{action}/{category?}", 
                                             defaults: new { Controller = "Products", action= "ProductList" });

                endpoints.MapControllerRoute(name:    "smartFilter", 
                                             pattern: "Products/{action}/{nameProduct&category?}", 
                                             defaults: new { Controller = "Products", action = "ProductListView" });
            });
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
               CatalogContext catalogContext = scope.ServiceProvider.GetRequiredService<CatalogContext>();

               //Инициализируем БД объектами из класса DBObject
               DBObject.Initial(catalogContext);
            }
        }
    }
}
