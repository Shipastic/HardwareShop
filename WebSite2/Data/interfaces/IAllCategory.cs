using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.Models;

namespace WebSite2.Data.interfaces
{
  public  interface IAllCategory
    {
        IEnumerable<MainCategory> MainCategories { get;}
    }
}
