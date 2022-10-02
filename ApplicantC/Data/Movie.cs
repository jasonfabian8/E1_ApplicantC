using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicantC.Data
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public int Rating { get; set; }
        public virtual List<Character> Characters { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
