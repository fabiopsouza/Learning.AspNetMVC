using System.Threading;
using System.Web.Mvc;
using Catalog.Models;

namespace Catalog.Controllers
{
    public class WaitController : Controller
    {
        // GET: Wait
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(WaitViewModel obj)
        {
            Thread.Sleep(5000);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}