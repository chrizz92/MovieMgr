using MovieMgr.Core.Contracts;
using MovieMgr.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMgr.Web.Models
{
    public class HomeStatisticsViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Category> Categories { get; set; }
        public int TopCategoryId { get; set; }
        public Movie LongestMovie { get; set; }

        public void LoadModelData(IUnitOfWork uow)
        { 
            Movies = uow.MovieRepository.GetMovies();
            Categories = uow.CategoryRepository.GetCategories();
            LongestMovie = Movies.Where(m => m.Duration == Movies.Max(m => m.Duration)).First();
            TopCategoryId = Movies.GroupBy(m => m.Category_Id).Select(grp => new
            {
                CategoryId = grp.Key,
                MovieCount = Movies.Count(mo => mo.Category_Id == grp.Key)
            }).OrderByDescending(grp => grp.MovieCount).First().CategoryId;
        }
    }
}
