using MovieMgr.Core.Contracts;
using MovieMgr.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMgr.Web.Models
{
    public class HomeDetailsViewModel
    {
        public List<Movie> Movies { get; set; }
        public Category Category { get; set; }

        public void LoadModelData(IUnitOfWork unitOfWork, int categoryId)
        {
            Movies = unitOfWork.MovieRepository.GetMoviesByCategoryId(categoryId);
            Category = unitOfWork.CategoryRepository.GetCategoryById(categoryId);
        }
    }
}
