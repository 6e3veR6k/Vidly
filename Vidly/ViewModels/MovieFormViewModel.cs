﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public int[] SelectedMovieGenres { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }
}