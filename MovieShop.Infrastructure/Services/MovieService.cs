using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Core.Entities;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Core.RepositoryInterfaces;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {


        //public List<Movie> getTop()
        //{
        // IMovieRepository m
        // MovieRepository1 m1 = new MovieRepository1()
        // MovieRepository2 m2 = new MovieRepository2()

        //talk with database through repo and get me top 20 movies
        //return new List<Movie>;
        //}

        private readonly IMovieRepository _movieRepository;
        // DI can be done in 3 ways
        //1. constructor injction 2. method injection 3. property injection
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository; //readonly can only be changed in constructor, we cannot change anywhere, so in DI, you must initialize in the constructor only
        }

        public IEnumerable<Core.Entities.Movie> GetHighestGrossingMovies()
        {
            return _movieRepository.GetHighestRatedMovies();
        }
    }
   
}
