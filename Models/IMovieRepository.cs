using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class IMovieRepository
    {
        // Base repository for movies
        IQueryable<Movie> movies { get; }
    }
}
