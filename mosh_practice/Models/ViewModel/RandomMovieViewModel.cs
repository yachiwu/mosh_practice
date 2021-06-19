using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mosh_practice.Models;


namespace mosh_practice.Models.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}