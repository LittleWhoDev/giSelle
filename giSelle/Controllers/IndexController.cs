using giSelle.Models;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace giSelle.Controllers
{
    public class IndexController : Controller
    {
        private readonly DomainDbContext db = new DomainDbContext();

        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return RedirectToAction("Index");
        }
    }
}