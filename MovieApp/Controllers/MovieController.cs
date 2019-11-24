using Microsoft.AspNet.Identity;
using MovieApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        MovieContext movieContext = new MovieContext();

        private bool CheckUser() =>
            string.IsNullOrEmpty(User.Identity.GetUserId());

        /// <summary>Список фильмов</summary>
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();

            ViewBag.Movies = movieContext
                                .Get();
                                //.OrderByDescending(e => e.CreatedDate);

            return View();
        }

        /// <summary>Создание нового фильма</summary>
        [HttpGet]
        public ActionResult Create()
        {
            //if (CheckUser())
            //    return RedirectToAction("Index", "Movie");

            return View();
        }

        [HttpPost]
        public ActionResult Create(MovieEnvelop movie)
        {
            //if (CheckUser())
            //    return RedirectToAction("Index", "Movie");

            if (movie.Picture != null)
            {
                string fileName = movie.Id.ToString();
                movie.Poster = fileName;
                movie.Picture.SaveAs(Server.MapPath("~/Files/" + fileName));
            }

            movieContext.Create(movie.Translate());
            return RedirectToAction("Index", "Movie");
        }

        /// <summary>Редактирование информации о фильме</summary>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            //if (string.IsNullOrEmpty(id))
            //    return RedirectToAction("Index", "Movie");

            var movie = movieContext.Get(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            //if (string.IsNullOrEmpty(id))
            //    return RedirectToAction("Index", "Movie");

            movieContext.Update(movie);
            return RedirectToAction("Index", "Movie");
        }
    }
}