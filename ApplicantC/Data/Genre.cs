using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicantC.Data
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Name", TypeName = "varchar")]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [Column("Image", TypeName = "varchar")]
        [MaxLength(500)]
        public string Image { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}
