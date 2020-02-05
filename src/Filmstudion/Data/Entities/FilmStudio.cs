using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.Data
{
    public class Filmstudio
    {
        [BindNever]
        public int FilmstudioId { get; set; }
       
        [Required(ErrorMessage = "Vänligen ange namnet på filmstudion")]
        public string FilmstudioName { get; set; }
        [Required(ErrorMessage = "Vänligen ange staden för filmstudion")]
        public string City { get; set; }
        public string Email { get; set; }
    }
}
