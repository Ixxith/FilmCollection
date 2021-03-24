using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class MovieDBContext : DbContext
    {
        // DBContext for Movies
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {

        }

        public DbSet<Movie> movies { get; set; }
    }
}
