using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MyMovieDb.Models
{
    public class Cast //junction table
    {
        public int CastID { get; set; }
        public int MovieID { get; set; }
        public int ActorID { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
