using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDotnetProject.Models;
using MVCDotnetProject.ViewModels;
using System.Data.Entity;

namespace MVCDotnetProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Details(int id)
        {
           Movie movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            } 
            return View(movie);
        }

        public ActionResult New()
        {
            List<Genre> genres = _context.Genres.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel
            {
                Genres = genres,
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

            return View("MovieForm", viewModel);
        }

        public ActionResult Index()
        {
            IEnumerable<Movie> movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }


        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.Stock = movie.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}