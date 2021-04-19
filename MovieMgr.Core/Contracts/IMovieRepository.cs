using System;
using System.Collections.Generic;
using System.Text;
using MovieMgr.Core.Entities;

namespace MovieMgr.Core.Contracts
{
    public interface IMovieRepository
    {
        int GetCount();
        List<Movie> GetMoviesByCategoryId(int categoryId);
        Movie GetMovieById(int movieId);
        void DeleteMovie(int id);
        void AddMovie(Movie movie);
        List<Movie> GetMovies();
    }
}
