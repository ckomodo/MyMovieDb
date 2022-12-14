using MyMovieDb.Models;
using System.Diagnostics;

namespace MyMovieDb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            
            if (context.Actors.Any())
            {
                return;
            }

            var actors = new Actor[]
            {
                new Actor{FirstName="John",LastName="Travolta",PlayingAS="Vincent Vega"},
                new Actor{FirstName="Samuel L",LastName="Jackson",PlayingAS="Jules Winfield"},
                new Actor{FirstName="Tim",LastName="Robbins",PlayingAS="Andy Dufresne"},
                new Actor{FirstName="Morgan",LastName="Freeman",PlayingAS="Ellis Redding"},
                new Actor{FirstName="Matthew",LastName="Broderick",PlayingAS="Simba"},
                new Actor{FirstName="James",LastName="Earl Jones",PlayingAS="Mufasa"}

            };
            context.Actors.AddRange(actors);
            context.SaveChanges();

            //if (context.Movies.Any())
            //{
            //    return;
            //}
            var movies = new Movie[]
            {
                new 
                Movie{MovieID=1050,
                    Title="Pulp Fiction",
                    ReleaseDate=DateTime.Parse("1994-09-01"),
                    Genre="Crime, Drama",
                    Price=10,
                    Rating="Mature Audience"},
                new 
                Movie{MovieID=4022,
                    Title="The Shawshank Redemption",
                    ReleaseDate=DateTime.Parse("1994-09-01"),
                    Genre="Drama",
                    Price=12,
                    Rating="General Audience"},
                new 
                Movie{MovieID=4041,
                    Title="The Lion King",
                    ReleaseDate = DateTime.Parse("1994-09-01"),
                    Genre="Animation,Drama",
                    Price=15,
                    Rating="General"}
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();

            var casts = new Cast[]
            {
                new Cast{ActorID=1,MovieID=1050},
                new Cast{ActorID=2,MovieID=1050},
                new Cast{ActorID=3,MovieID=4022},
                new Cast{ActorID=4,MovieID=4022},
                new Cast{ActorID=5,MovieID=4041},
                new Cast{ActorID=6,MovieID=4041}
            };

            context.Casts.AddRange(casts);
            context.SaveChanges();
        }
    }
}