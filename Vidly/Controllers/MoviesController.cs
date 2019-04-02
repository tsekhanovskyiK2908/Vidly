using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
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

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if(movie==null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        //private IEnumerable<Movie>GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie{Id = 4, Name = "Fast & Furious"},
        //        new Movie{Id = 5, Name = "Transporter 3"}
        //    };
        //}

        // GET: Movies

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {                   
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {    
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {   
                    Genres = _context.Genres.ToList()                   
                };

                return View("MovieForm", viewModel);
            }

            if(movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movie==null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Fast & Furious", Id = 1 };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello, world!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

















        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"The year is {year} and the month is {month}");
        }

        //public ActionResult Edit(int id)
        //{
        //    return Content($"Id = {id}");
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if(!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if(string.IsNullOrEmpty(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content($"pageIndex = {pageIndex}&sortBy = {sortBy}");
        //}
    }
}