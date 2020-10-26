using giSelle.Models;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace giSelle.Controllers
{
    public class IndexController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: Index
        public ActionResult Index()
        {
            var u = from usr in db.Users select usr;
            var k = u.ToArray();
            foreach (var i in k)
            {
                Debug.WriteLine("{0} - {1}", i.Name, i.RoleId);
            }

            return View();
        }
    }
}