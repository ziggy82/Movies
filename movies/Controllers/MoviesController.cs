using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movies.Models;

//using movies.Models;


namespace movies.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
           // _context.Movies.Include(movies => movies.
           var movies = _context.Movies.Include(a => a.Genre).ToList();
           return View(movies);
        }

        public ActionResult Details(int id)
        {
           var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
           if (movie == null)
           {
               return HttpNotFound();
           }

           return View(movie);
        }

        //public IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie {Id = 1, Name = "Shrek"},
        //        new Movie {Id = 2, Name = "Wall-e" }
        //    };
        //}

        //public ActionResult Random()
        //{
        //    var movie = new Movie { Name = "Shrek" };


        //    var customer = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customer
        //    };

        //    return View(viewModel);
        //}
        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}