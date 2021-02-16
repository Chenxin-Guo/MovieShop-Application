using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Core.Entities;

// repository is related to business logic and service folder is related to database
namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetTopRevenueMovies();
        IEnumerable<Movie> GetHighestRatedMovies();
    }
}
