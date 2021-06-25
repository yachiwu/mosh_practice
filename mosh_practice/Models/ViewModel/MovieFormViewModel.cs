﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mosh_practice.Models.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                {
                    return "Edit Movie";
                }
                else
                {
                    return "New Movie";
                }
            }
                    
        }

    }
}