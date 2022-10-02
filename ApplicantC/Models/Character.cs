using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicantC.Models
{
    public class CharacterDetail
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Story { get; set; }
        public Movie[] Movies { get; set; }
    }

    public class Character
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}