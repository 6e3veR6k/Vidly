using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
            var selectedMovie = _context.Movies.Include(m => m.Genres).Include(m => m.Rating).Single(m => m.Id == id);


            var movieForm = new MovieFormViewModel(selectedMovie)
            {
                GenresInDb = _context.Genres.ToList(),
                RatingsInDb = _context.Ratings.ToList()
            };
            return View("MovieForm", movieForm);
        }

        public ActionResult NewMovie()
        {

            var movieForm = new MovieFormViewModel
            {
                GenresInDb = _context.Genres.ToList(),
                RatingsInDb = _context.Ratings.ToList()
            };

            return View("MovieForm", movieForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel movieForm)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    ImgPath = movieForm.ImgPath,
                    OriginalTitle = movieForm.OriginalTitle,
                    ReleaseDate = movieForm.ReleaseDate,
                    Director = movieForm.Director,
                    Description = movieForm.Description,
                    GenreIds = movieForm.GenreIds,
                    RatingId = movieForm.RatingId,
                    GenresInDb = _context.Genres.ToList(),
                    RatingsInDb = _context.Ratings.ToList()
                };
                return View("MovieForm", viewModel);
            }

            var selectedGenres = _context.Genres.Join(movieForm.GenreIds, g => g.Id, x => x, (g, x) => g).ToList();

            if(movieForm.Id == 0)
            {
                var movie = new Movie
                {
                    ImgPath = movieForm.ImgPath,
                    OriginalTitle = movieForm.OriginalTitle,
                    RatingId = movieForm.RatingId.Value,
                    Genres = selectedGenres,
                    NumberInStock = movieForm.NumberInStock,
                    ReleaseDate = movieForm.ReleaseDate.Value,
                    Director = movieForm.Director,
                    Description = movieForm.Description,
                };
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Include(m => m.Genres).Include(m => m.Rating).Single(m => m.Id == movieForm.Id);

                movieInDb.ImgPath = movieForm.ImgPath;
                movieInDb.OriginalTitle = movieForm.OriginalTitle;
                //movieInDb.Rating = movie.Rating;
                movieInDb.RatingId = movieForm.RatingId.Value;
                movieInDb.Genres = selectedGenres;
                movieInDb.NumberInStock = movieForm.NumberInStock;
                movieInDb.ReleaseDate = movieForm.ReleaseDate.Value;
                movieInDb.Director = movieForm.Director;
                movieInDb.Description = movieForm.Description;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            

            return RedirectToAction("Index", "Movies");
        }


    }
}