using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDotnetProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCDotnetProject.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Stock need to be between 1-20")]
        [Display(Name = "Number in Stock")]
        public int? Stock { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public string Title { get { return Id != 0 ? "Edit Movie" : "New Movie"; } }
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Stock = movie.Stock;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
        }

        }
    }