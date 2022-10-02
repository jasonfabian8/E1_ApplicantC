using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicantC.Data
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Image", TypeName = "varchar")]
        [MaxLength(500)] 
        public string Image { get; set; }

        [Required]
        [Column("Title", TypeName = "varchar")]
        [MaxLength(500)] 
        public string Title { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public int Rating { get; set; }
        
        public virtual List<Character> Characters { get; set; }

        [Required]
        public int GenreId { get; set; }
        [Required]
        public virtual Genre Genre { get; set; }
    }
}
