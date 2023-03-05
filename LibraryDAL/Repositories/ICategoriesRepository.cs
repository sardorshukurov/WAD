using System.Collections.Generic;
using WAD.Models;

namespace CategoryStoreAPI.Repositories
{
    public interface ICategoriesRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(int categoryID, Category updatedCategory);
        void DeleteCategory(int categoryID);
        Category GetCategoryByID(int categoryID);
        IEnumerable<Category> GetCategories();
    }
}
