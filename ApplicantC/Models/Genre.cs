namespace ApplicantC.Models
{
    public class Genre
    {
        public string Name { get; set; }    
        public string Image { get; set; }   
        public Movie[] Movies { get; set; }
       
    }
}

