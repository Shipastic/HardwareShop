using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data;
using WebSite2.Data.interfaces;
using WebSite2.Data.Models;
using WebSite2.ViewModels;

namespace WebSite2.Components
{
    public class Timer : ViewComponent
    {
        //public string Invoke()
        //{
        //    return $"Текущее время: {DateTime.Now.ToString("hh:mm:ss")}";
        //}

        private CatalogContext _catalogContext;

        private IAllFilterName _allFilterName;

        public IEnumerable<FilterName> FilterNames;

        public ICatalogGroup _catalogGroups;

        public Timer(CatalogContext catalogContext, IAllFilterName allFilterName, ICatalogGroup catalogGroup)
        {
            _catalogContext = catalogContext;

            _allFilterName = allFilterName;

            _catalogGroups = catalogGroup;
        }

        public async Task<IViewComponentResult> InvokeAsync(string category)
        {
            IEnumerable<CatalogGroup> catalogGroups = null;

            IEnumerable<FilterName> filterNames = null;

            if (category == null)
            {
                filterNames = _allFilterName.FilterNamesToFilterGroups.OrderBy(f => f.FilterNameId);
            }
            else
            if(category == "Материнские платы")
            {
                filterNames = _allFilterName.GetFilterNamesByCatalogGroup.Where(g => g.CatalogGroup.GroupName.Equals(category));
            }

            var timerObj = new TimerViewModel
            {
                Filters = filterNames
            };

            return View(timerObj);
        }


    }
}
