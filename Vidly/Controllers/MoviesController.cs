﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public IEnumerable<Movie> Movies => new List<Movie>()
        {
            new Movie { Id = 1, ImgPath = "/Content/Images/diehard.jpg", OriginalTitle = "Die Hard", Director = "John McTiernan", Genre = "Action", Rating = "PG-13", ReleaseDate = new DateTime(1988, 7, 20), Description = "John McClane, officer of the NYPD, tries to save his wife Holly Gennaro and several others that were taken hostage by German terrorist Hans Gruber during a Christmas party at the Nakatomi Plaza in Los Angeles." },
            new Movie { Id = 2, ImgPath = "/Content/Images/frozen.jpg", OriginalTitle = "Frozen", Director = "Jennifer Lee", Genre = "Animation", Rating = "G", ReleaseDate = new DateTime(2013, 12, 12), Description = "When the newly-crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister Anna teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition." },
            new Movie { Id = 3, ImgPath = "/Content/Images/redemption.jpg", OriginalTitle = "The Shawshank Redemption", Director = "Frank Darabont", Genre = "Drama", Rating = "PG", ReleaseDate = new DateTime(1994, 10, 14), Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency." },
            new Movie { Id = 4, ImgPath = "/Content/Images/thedarkknight.jpg", OriginalTitle = "The Dark Knight", Director = "Christopher Nolan", Genre = "Crime", Rating = "PG-13", ReleaseDate = new DateTime(2008, 10, 14), Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
        };

        public ActionResult Index()
        {
            return View(Movies);
        }

        [Route("movies/details/{id:regex(\\d{1}):range(1,4)}")]
        public ActionResult Details(int id)
        {
            var movie = Movies.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }
    }
}