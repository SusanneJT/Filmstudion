using Filmstudion.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Models
{
    public class Rating
    {
        [BindNever]
        public int RatingId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int FilmstudioId { get; set; }
        [BindNever]
        public Filmstudio Filmstudio { get; set; }

        [Required(ErrorMessage = "Vänligen ange ett betyg mellan 1 till 5")]
        [Range(1, 5)]
        public int Grade { get; set; }
       
    }
}
