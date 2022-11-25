//using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovieDb.Models
{
    public class Movie
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public string Rating { get; set; }
        public string Poster { get; set; }
        public ICollection<Cast> Casts { get; set; }

    }
}