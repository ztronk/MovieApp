using Microsoft.AspNet.Identity;
using MovieApp.Models;
using PagedList;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        MovieContext movieContext = new MovieContext();

        private bool CheckUser() =>
            string.IsNullOrEmpty(User.Identity.GetUserId());

        /// <summary>Список фильмов</summary>
        public ActionResult Index(int? page)
        {
            ViewBag.UserId = User.Identity.GetUserId();

            var movies = movieContext
                            .Get()
                            .OrderByDescending(e => e.CreatedDate);

            int pageSize = Config.PageSize;
            int pageNumber = (page ?? 1);

            return View(movies.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>Создание нового фильма</summary>
        [HttpGet]
        public ActionResult Create()
        {
            if (CheckUser())
                return RedirectToAction("Index", "Movie");

            return View();
        }

        [HttpPost]
        public ActionResult Create(MovieEnvelop movie)
        {
            try
            {
                if (CheckUser())
                    return RedirectToAction("Index", "Movie");

                if (ModelState.IsValid)
                {
                    if (movie.Picture != null)
                    {
                        string fileName = movie.Id.ToString();
                        string extFile = Path.GetExtension(movie.Picture.FileName);
                        movie.Poster = string.Format("{0}{1}", fileName, extFile);
                        movie.Picture.SaveAs(Server.MapPath($"~/Files/{fileName}{extFile}"));
                    }

                    movie.CreatedDate = DateTime.Now;
                    movie.UserId = User.Identity.GetUserId();
                    movieContext.Create(movie.Translate());
                    return RedirectToAction("Index", "Movie");
                }
                else
                    return View(movie);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Movie");
            }
        }

        /// <summary>Редактирование информации о фильме</summary>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            if (CheckUser())
                return RedirectToAction("Index", "Movie");

            var movie = movieContext.Get(id);
            var movieEnvelop = movie.Translate();
            return View(movieEnvelop);
        }

        [HttpPost]
        public ActionResult Edit(MovieEnvelop movie)
        {
            try
            {
                if (CheckUser())
                    return RedirectToAction("Index", "Movie");

                if (ModelState.IsValid)
                {
                    if (movie.Picture != null)
                    {
                        string fileName = movie.Id.ToString();
                        string extFile = Path.GetExtension(movie.Picture.FileName);
                        movie.Poster = string.Format("{0}{1}", fileName, extFile);
                        movie.Picture.SaveAs(Server.MapPath($"~/Files/{movieContext.Get(movie.Id).Poster}"));
                    }

                    movieContext.Update(movie.Translate());
                    return RedirectToAction("Index", "Movie");
                }
                else
                    return View(movie);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Movie");
            }
        }

        /// <summary>Просмотр информации о фильме</summary>
        [HttpGet]
        public ActionResult Review(Guid id)
        {
            var movie = movieContext.Get(id);
            return View(movie);
        }
    }
}