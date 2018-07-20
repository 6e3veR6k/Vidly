﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

        public Genre()
        {
            Movies = new List<Movie>();
        }
    }
}