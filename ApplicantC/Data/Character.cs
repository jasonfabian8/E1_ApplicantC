using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicantC.Data
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Story { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
