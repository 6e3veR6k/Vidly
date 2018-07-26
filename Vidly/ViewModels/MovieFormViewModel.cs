using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ImgPath { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Title")]
        public string OriginalTitle { get; set; }

        [Required]
        [Display(Name = "Release")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Director { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Count")]
        [Range(1, 10)]
        public int NumberInStock { get; set; }

        [Required]
        public int[] GenreIds { get; set; }

        [Required]
        public byte? RatingId { get; set; }

        public IEnumerable<Genre> GenresInDb { get; set; }
        public IEnumerable<Rating> RatingsInDb { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            ImgPath = movie.ImgPath;
            OriginalTitle = movie.OriginalTitle;
            ReleaseDate = movie.ReleaseDate;
            Director = movie.Director;
            Description = movie.Description;
            GenreIds = movie.Genres.Select(x => (int)x.Id).ToArray();
            RatingId = movie.RatingId;
        }
    }
}