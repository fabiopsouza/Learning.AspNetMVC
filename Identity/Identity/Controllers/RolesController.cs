using System.Linq;
using System.Web.Mvc;
using Identity.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Controllers
{
    public class RolesController : Controller
    {
        readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(_context.Roles.ToList());
        }

        [HttpPost]
        public JsonResult Create(IdentityRole role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();

            return Json(_context.Roles.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(IdentityRole role)
        {
            _context.Entry(role).State = EntityState.Modified;
            _context.SaveChanges();

            return Json(_context.Roles.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(IdentityRole role)
        {
            _context.Entry(role).State = EntityState.Deleted;
            _context.SaveChanges();

            return Json(_context.Roles.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRoleById(string id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == id);
            return Json(role, JsonRequestBehavior.AllowGet);
        }
    }
}