using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApplicantC.Data;
using System.Security.Cryptography;
using System.Text;

namespace ApplicantC.Models
{
    public class UserInfo
    {
        internal string PasswordHash
        {
            get
            {
                return ASCIIEncoding.UTF8.GetString(MD5.HashData(ASCIIEncoding.UTF8.GetBytes(Password)));
            }
        }

        [Required]
        [MaxLength(500)]
        public string Username { get; set; }

        [Required]
        [MaxLength(500)]
        public string Password { get; set; }
    }
}
