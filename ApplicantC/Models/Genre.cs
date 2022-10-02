using System.ComponentModel.DataAnnotations;

namespace ApplicantC.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }   
        public Movie[] Movies { get; set; }
       
    }
}

