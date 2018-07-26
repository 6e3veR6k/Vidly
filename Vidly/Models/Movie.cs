using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
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
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Director { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Count")]
        public int NumberInStock { get; set; }

        [Required]
        public ICollection<Genre> Genres { get; set; }

        public byte RatingId { get; set; }
        public Rating Rating { get; set; }

        public Movie()
        {
            Genres = new List<Genre>();
        }
    }
}