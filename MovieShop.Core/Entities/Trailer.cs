using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Core.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        // you can also explicitly set foreign key: [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }
        public Movie Movie { get; set; } // single entity
    }
}
