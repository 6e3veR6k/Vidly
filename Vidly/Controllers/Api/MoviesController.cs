using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        #region Initialization
        private VidlyDbContext _context;
        public MoviesController()
        {
            _context = new VidlyDbContext();
        }
        #endregion Initialization

        #region ApiPublicMthods

        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.Include(m => m.Rating).Include(m => m.Genres).ToList();

            return Ok(movies);
        }

        #endregion ApiPublicMthods

    }
}
