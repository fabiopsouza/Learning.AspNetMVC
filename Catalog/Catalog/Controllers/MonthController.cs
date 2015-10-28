using System.Collections.Generic;
using System.Linq;
using Catalog.Infrastructure.Repositories;
using System.Web.Mvc;
using Catalog.Models;

namespace Catalog.Controllers
{
    public class MonthController : Controller
    {
        // GET: Month
        public ActionResult Index()
        {
            using (var monthRep = new MonthRepository())
            {
                var months = monthRep.Get();

                var monthsViewModel = months.Select(month => new MonthViewModel()
                {
                    Id = month.Id, 
                    MonthName = month.MonthName, 
                    Value = month.Value
                }).ToList();

                return View(monthsViewModel);
            }
        }

        [HttpPost]
        public ActionResult UpdateChart(MonthViewModel monthViewModel)
        {
            using (var monthRep = new MonthRepository())
            {
                
            }

            return RedirectToAction("Index");
        }
    }
}