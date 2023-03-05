using BookStoreAPI.Exceptions;
using CategoryStoreAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using WAD.Data;
using WAD.Models;

namespace BookStoreAPI.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly StoreContext _dbContext;

        public CategoriesRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCategory(int categoryID)
        {
            Category category = _dbContext.Categories.Find(categoryID);
            if (category == null)
            {
                throw new AppException($"Category with ID {categoryID} not found.");
            }
            try
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {

                throw new AppException($"An error occurred while deleting category with ID {categoryID}.", ex);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            try
            {
                IEnumerable<Category> categories = _dbContext.Categories.ToList();
                if (categories == null)
                {
                    throw new AppException($"Categories are not found.");
                }
                return categories;
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while retrieving categories.", ex);
            }
        }

        public Category GetCategoryByID(int categoryID)
        {
            try
            {
                Category category = _dbContext.Categories.Find(categoryID);
                if (category == null)
                {
                    throw new AppException($"Category with ID {categoryID} not found.");
                }
                return category;
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while retrieving category with ID {categoryID}.", ex);
            }
        }

        public void InsertCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category), "The category parameter cannot be null.");
                }

                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new AppException("An error occurred while inserting a new category.", ex);
            }
        }

        public void UpdateCategory(int categoryID, Category updatedCategory)
        {
            try
            {
                Category category = _dbContext.Categories.Find(categoryID);
                if (category == null)
                {
                    throw new AppException($"Category with ID {categoryID} not found.");
                }

                _dbContext.Entry(category).State = EntityState.Modified;

                category.Name = updatedCategory.Name;
                category.Description = updatedCategory.Description;

                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while updating the category with ID {categoryID}.", ex);
            }
        }
    }
}
