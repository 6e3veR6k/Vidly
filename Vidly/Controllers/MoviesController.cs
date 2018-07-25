using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //public IEnumerable<Movie> Movies => new List<Movie>()
        //{
        //    new Movie { Id = 1, ImgPath = "/Content/Images/diehard.jpg", OriginalTitle = "Die Hard", Director = "John McTiernan", Genre = "Action", Rating = "PG-13", ReleaseDate = new DateTime(1988, 7, 20), Description = "John McClane, officer of the NYPD, tries to save his wife Holly Gennaro and several others that were taken hostage by German terrorist Hans Gruber during a Christmas party at the Nakatomi Plaza in Los Angeles." },
        //    new Movie { Id = 2, ImgPath = "/Content/Images/frozen.jpg", OriginalTitle = "Frozen", Director = "Jennifer Lee", Genre = "Animation", Rating = "G", ReleaseDate = new DateTime(2013, 12, 12), Description = "When the newly-crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister Anna teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition." },
        //    new Movie { Id = 3, ImgPath = "/Content/Images/redemption.jpg", OriginalTitle = "The Shawshank Redemption", Director = "Frank Darabont", Genre = "Drama", Rating = "PG", ReleaseDate = new DateTime(1994, 10, 14), Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency." },
        //    new Movie { Id = 4, ImgPath = "/Content/Images/thedarkknight.jpg", OriginalTitle = "The Dark Knight", Director = "Christopher Nolan", Genre = "Crime", Rating = "PG-13", ReleaseDate = new DateTime(2008, 10, 14), Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
        //};

        private readonly VidlyDbContext _context;

        public MoviesController()
        {
            _context = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genres).Include(m => m.Rating).FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();


            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult NewMovie()
        {
            var genres = _context.Genres.ToList();
            var ratings = _context.Ratings.ToList();
            var movieForm = new MovieFormViewModel
            {
                Genres = genres,
                Ratings = ratings
            };

            return View("MovieForm", movieForm);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel movieView)
        {
            var movie = movieView.Movie;

            movie.Genres = _context.Genres.Join(movieView.SelectedMovieGenres, g => g.Id, x => x, (g, x) => g).ToList();

            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.ImgPath = movie.ImgPath;
                movieInDb.OriginalTitle = movie.OriginalTitle;
                movieInDb.Rating = movie.Rating;
                movieInDb.Genres = movie.Genres;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Director = movie.Director;
                movieInDb.Description = movie.Description;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


    }
}