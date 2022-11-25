namespace MyMovieDb.Models
{
    public class Actor
    {
        public int ID { get; set; }
        public string Movie { get; set; }
        public string MovieID { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string PlayingAS { get; set; }
        public ICollection<Cast> Casts { get; set; }
    }
}
