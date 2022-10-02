using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicantC.Data
{
    public class Character
    {
        [Key]
        public int Id { get; set; }


        [Column("Image", TypeName = "varchar")]
        [MaxLength(500)]
        public string Image { get; set; }

        [Column("Name", TypeName = "varchar")]
        [MaxLength(500)] 
        public string Name { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        [Column("Story", TypeName = "varchar")]
        [MaxLength(500)] 
        public string Story { get; set; }
        public virtual IList<Movie> Movies { get; set; }
    }
}
