using Microsoft.AspNet.Identity;
using MovieApp.Models;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        MovieContext movieContext = new MovieContext();

        /// <summary>Список фильмов</summary>
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();

            ViewBag.Movies = movieContext.Get();
            return View();
        }
    }
}