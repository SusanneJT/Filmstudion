using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data
{
    public class Movie
    {
        [BindNever]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Vänligen ange en titel på filmen")]
        public string MovieTitle { get; set; }
        public string StoryLine { get; set; }

        [Required(ErrorMessage = "Vänligen ange max antal utlåningar")]
        [Range(1, 10)]
        public int MaxLendings { get; set; }

        public bool AvailableForLending { get; set; }

        //public List<Lending> ActiveLendings { get; set; }
        //public List<Rating> Ratings { get; set; }
        //public List<Trivia> Trivia { get; set; }   
    }
}
