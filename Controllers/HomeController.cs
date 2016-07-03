using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        private UserManager<ContractUser> manager;

        public HomeController()
        {
            manager = new UserManager<ContractUser>(new UserStore<ContractUser>(db));

        }

        public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return View(db.Contracts.Where(c => c.Owner.Id == currentUser.Id).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult David()
        {
            return View();
        }
    }
}