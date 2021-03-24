using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDBContext _context;
        private IMovieRepository _repository; 

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MovieDBContext context)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
            
        }

        // Home view
        public IActionResult Index()
        {
            return View();
        }
        // Podcast view

        public IActionResult Podcast()
        {
            return View();
        }

        // Form for submitting a new movie

        [HttpGet]
        public IActionResult SubmitMovie()
        {
            return View();
        }

        // Post for a new movie

        [HttpPost]
        public IActionResult SubmitMovie(Movie movie)
        {
           if (ModelState.IsValid) {
                // If valid, add movie to database and save changes
                _context.movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("ViewMovies");
            }
            return View();
        }

        // View for Movie list
        [HttpGet]
        public IActionResult ViewMovies()
        {
            // Lists the movies and allows you to edit/delete them 
            IEnumerable<Movie> movies = _context.movies.OrderBy(m => m.MovieId);
            return View(movies);
        
        }

        // View to Delete movies
        [HttpPost]
        public IActionResult ViewMovies(int movieId)
        {
            // Get the movie, remove from database, save changes
            var movie = _context.movies.First(m => m.MovieId == movieId);
            _context.movies.Remove(movie);
            _context.SaveChanges();
            IEnumerable<Movie> movies = _context.movies.OrderBy(m => m.MovieId);
            return View(movies);
        }

        // View to edit a movie
        [HttpGet]
        public IActionResult Edit(int movieId)
        {
            // Pass the movie matching the movie id passed as a parameter from url
            var movie = _context.movies.First(m => m.MovieId == movieId);
            
            return View(movie);
        }
        // View to post an editted movie
        [HttpPost]
        public IActionResult Edit(int movieId, Movie movie)
        {
            // If the movie is valid, update the database and save changes
            if (ModelState.IsValid)
            {
                _context.movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("ViewMovies");
            }
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
