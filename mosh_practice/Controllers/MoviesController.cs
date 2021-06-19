using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mosh_practice.Models;
using mosh_practice.Models.ViewModel;

namespace mosh_practice.Controllers
{
    public class MoviesController : Controller
    {
        //連接資料庫
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //釋放非受控資源
        protected override void Dispose(bool disposing) //釋放非受控資源
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);

        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null) { return HttpNotFound(); }
            return View(movie);
        }


        // GET: Movies/Random
        public ActionResult Random()

        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>()
            { new Customer {Name="C1"},
              new Customer {Name="C2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
        /*
        [Route("movies/released/{year}/{month:regex(\\d{2}:range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult Edit(int id)
        {
            return Content("id" + id);
        }
        */
        // url:movies
       
        


    }
}