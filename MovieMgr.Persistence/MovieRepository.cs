using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieMgr.Core.Contracts;
using MovieMgr.Core.Entities;

namespace MovieMgr.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            _dbContext.Movies.Remove(_dbContext.Movies.Where(m=>m.Id==id).First());
        }

        public int GetCount()
        {
            return _dbContext.Movies.Count();
        }

        public Movie GetMovieById(int movieId)
        {
            return _dbContext.Movies.Where(m => m.Id == movieId).First();
        }

        public List<Movie> GetMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public List<Movie> GetMoviesByCategoryId(int categoryId)
        {
            return _dbContext.Movies.Include(m=>m.Category).Where(m => m.Category_Id == categoryId).OrderBy(m=>m.Title).ToList();
        }
    }
}