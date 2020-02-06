using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Models
{
    public class Trivia
    {
        [BindNever]
        public int TriviaId { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public string TriviaContent { get; set; }


    }
}
