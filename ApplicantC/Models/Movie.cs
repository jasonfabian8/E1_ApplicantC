using System.Security.Policy;

namespace ApplicantC.Models
{
    public class Movie
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public int Rating { get; set; }
        public Character[] Characters { get; set; }

    }
}
