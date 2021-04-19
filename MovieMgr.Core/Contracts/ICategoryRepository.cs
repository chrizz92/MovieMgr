using System;
using System.Collections.Generic;
using System.Text;
using MovieMgr.Core.Entities;

namespace MovieMgr.Core.Contracts
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void AddCategory(string categoryName);
        Category GetCategoryById(int categoryId);
    }
}
