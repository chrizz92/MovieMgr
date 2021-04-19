using System.Collections.Generic;
using System.Linq;
using MovieMgr.Core.Contracts;
using MovieMgr.Core.Entities;

namespace MovieMgr.Persistence
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCategory(string categoryName)
        {
            _dbContext.Categories.Add(new Category() { CategoryName = categoryName });
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.OrderBy(c=>c.CategoryName).ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.Where(c => c.Id == categoryId).First();
        }
    }
}