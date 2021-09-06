using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite2.Data.Models;

namespace WebSite2.ViewModels
{
    public class TimerViewModel
    {
       public IEnumerable<FilterName> Filters { get; set; }
    }
}
