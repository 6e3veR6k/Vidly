using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public string OriginalTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

        public byte RatingId { get; set; }
        public virtual Rating Rating { get; set; }

        public Movie()
        {
            Genres = new List<Genre>();
        }
    }
}