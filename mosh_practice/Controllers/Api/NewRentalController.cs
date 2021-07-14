using mosh_practice.Dtos;
using mosh_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace mosh_practice.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        //POST/api/NewRental 新增租借
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No Movies Ids have been given"); //Edge Case : No MoviesId
            }
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId); //get the customer
            if (customer == null)
            {
                return BadRequest("CustomerId is not valid"); //Edge Case :CustomerId is invalid
            };

            
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more  MoviesId are invalid"); //Edge Case :One or more  MoviesId are invalid
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                {
                    return BadRequest("Movie is not available."); //Edge Case : One or more  Movies are not available 
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();


        }
            
    }
    
}