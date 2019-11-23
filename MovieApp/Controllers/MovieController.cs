using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }
    }
}