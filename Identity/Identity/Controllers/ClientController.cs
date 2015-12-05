using System.Web.Mvc;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Identity.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel client)
        {
            if (!ModelState.IsValid) return View();

            //Register user and SingIn
            var accountController = new AccountController {ControllerContext = this.ControllerContext};
            var user = accountController.RegisterAccount(new RegisterViewModel() { Email = client.Email, Password = client.Password });
            accountController.SignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

            //Add user to client role
            var userStore = new UserStore<ApplicationUser>(_context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(_context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            
            if (!roleManager.RoleExists("Client")) 
                roleManager.Create(new IdentityRole("Client"));
            
            userManager.AddToRole(user.Id, "Client");

            //Register client
            if (string.IsNullOrWhiteSpace(user.Id)) return View();
            _context.Clients.Add(new Client()
            {
                Id = user.Id,
                Name = client.Name,
                Age = client.Age
            });
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}