using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {   
            if(newRental.MoviesIds.Count==0)
            {
                return BadRequest("No Movies have been given.");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if(customer==null)
            {
                return BadRequest("Customer is not valid.");
            }

            var movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList();

            if(movies.Count != newRental.MoviesIds.Count)
            {
                return BadRequest("One or more movies are invalid.");
            }

            foreach(var movie in movies)
            {   
                if(movie.NumberAvaliable==0)
                {
                    return BadRequest($"Movie {movie.Id} is not avaliable.");
                }

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                movie.NumberAvaliable--;

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
