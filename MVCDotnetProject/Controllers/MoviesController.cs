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
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 01, Name = "Bruce Almighty"};


            List<Customer> customers = new List<Customer>
            {
                new Customer {Name = "Qu" },
                new Customer {Name = "Mark" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        [Route("movie/released/{year:regex(\\d4)}/{month:regex(\\d2):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}