using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicantC.Data
{
    public class User
    {
        [Key]
        [Column("Username", TypeName = "varchar")]
        [MaxLength(500)]
        public string Username { get; set; }

        [Required]
        [Column("Password", TypeName = "varchar")]
        [MaxLength(500)]
        public string Password { get; set; }
    }
}
