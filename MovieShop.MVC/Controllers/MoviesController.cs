using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Infrastructure.Services;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        // https://localhost:44363/Movies/Index, we usually delete controller from the class name
        // https://localhost:44363/movies/Index
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public IActionResult Details()
        {
            //by default when u have return view(), but you can change that.
            return View();
            //return View("Testing");
        }
        [HttpGet]
        public IActionResult TopRevenueMovies()
        {
            var movies = _movieService.GetHighestGrossingMovies();
            return View(movies);    
        }

        [HttpGet]
        public IActionResult TopRatedMovies()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Genre(int genreId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reviews(int movieId)
        {
            return View();
        }

    }
}
