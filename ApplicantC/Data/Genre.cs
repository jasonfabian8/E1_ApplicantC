using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicantC.Data
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
