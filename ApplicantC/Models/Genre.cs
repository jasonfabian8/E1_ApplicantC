namespace ApplicantC.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Image { get; set; }   
        public Movie[] Movies { get; set; }
       
    }
}

