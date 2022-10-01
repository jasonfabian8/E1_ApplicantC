using System;

namespace ApplicantC.Models
{
    public class Character
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Story { get; set; }
        public Movie[] Movies { get; set; }
    }
}