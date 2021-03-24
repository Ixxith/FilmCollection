using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class EFMovieRepo : IMovieRepository
    {
        private MovieDBContext _context;

        public EFMovieRepo(MovieDBContext context)
        {
            _context = context;
        }
        public IQueryable<Movie> books => _context.movies;
    }

}
