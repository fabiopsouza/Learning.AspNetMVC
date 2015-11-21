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
            return View();
        }

        public JsonResult GetMonths()
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

                return Json(monthsViewModel, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateMonths(MonthViewModel[] monthViewModel)
        {
            using (var monthRep = new MonthRepository())
            {
                if (monthViewModel == null) return null;

                foreach (var item in monthViewModel)
                {
                    var month = monthRep.GetByName(item.MonthName);

                    if (month.Value == item.Value) continue;
                    month.Value = item.Value;
                    monthRep.Edit(month);
                }
            }

            return Json(monthViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}