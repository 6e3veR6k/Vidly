using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rating
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Symbol { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }

        [Required]
        [StringLength(255)]
        public string Level { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Rating()
        {
            Movies = new List<Movie>();
        }
    }
}