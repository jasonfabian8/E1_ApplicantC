using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ApplicantC.Models
{
    public class Movie
    {
        
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string CreatedDate { get; set; }
        [Required]
        public int Rating { get; set; }
        public Character[] Characters { get; set; }

    }
}
