using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        // https://localhost:44363/Movies/Index, we usually delete controller from the class name
        // https://localhost:44363/movies/Index
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
            return View();
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
