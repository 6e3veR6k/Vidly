﻿using System;
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
        public string OriginalTitle { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Director { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public byte RatingId { get; set; }
        public Rating Rating { get; set; }

        public Movie()
        {
            Genres = new List<Genre>();
        }
    }
}