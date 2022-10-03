using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicantC.Models
{
    public class Movie
    {
        
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    public class MovieDetail
    {

        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int Rating { get; set; }
        public Character[] Characters { get; set; }
        public int GenreId { get; set; }
    }
}
