using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCDotnetProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,20,ErrorMessage ="Stock need to be between 1-20")]
        [Display(Name ="Number in Stock")]
        public int Stock { get; set; }
        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

    }
}