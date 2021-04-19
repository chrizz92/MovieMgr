using MovieMgr.Core.Contracts;
using MovieMgr.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMgr.Web.Models
{
    public class MovieDeleteViewModel
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int CategoryId { get; set; }

        public void LoadModelData(IUnitOfWork uow,int movieId)
        {
            Movie = uow.MovieRepository.GetMovieById(movieId);
            MovieId = movieId;
            CategoryId = Movie.Category_Id;
        }
    }
}
