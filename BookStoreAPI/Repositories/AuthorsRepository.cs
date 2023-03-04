using BookStoreAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using WAD.Data;
using WAD.Models;

namespace BookStoreAPI.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly StoreContext _dbContext;

        public AuthorsRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteAuthor(int authorID)
        {
            Author author = _dbContext.Authors.Find(authorID);
            if (author == null)
            {
                throw new AppException($"Author with ID {authorID} not found.");
            }

            try
            {
                _dbContext.Authors.Remove(author);
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while deleting author with ID {authorID}.", ex);
            }
        }

        public IEnumerable<Author> GetAuthors()
        {
            try
            {
                IEnumerable<Author> authors = _dbContext.Authors.ToList();
                if (authors == null)
                {
                    throw new AppException($"Authors are not found.");
                }
                return authors;
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while retrieving authors.", ex);
            }
        }

        public Author GetAuthorByID(int authorID)
        {
            try
            {
                Author author = _dbContext.Authors.Find(authorID);
                if (author == null)
                {
                    throw new AppException($"Author with ID {authorID} not found.");
                }
                return author;
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while retrieving author with ID {authorID}.", ex);
            }
        }

        public void InsertAuthor(Author author)
        {
            try
            {
                if (author == null)
                {
                    throw new ArgumentNullException(nameof(author), "The author parameter cannot be null.");
                }

                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new AppException("An error occurred while inserting a new author.", ex);
            }
        }

        public void UpdateAuthor(int authorID, Author updatedAuthor)
        {
            try
            {
                Author author = _dbContext.Authors.Find(authorID);
                if (author == null)
                {
                    throw new AppException($"Author with ID {authorID} not found.");
                }

                _dbContext.Entry(author).State = EntityState.Modified;

                author.FirstName = updatedAuthor.FirstName;
                author.LastName = updatedAuthor.LastName;
                author.Biography = updatedAuthor.Biography;

                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while updating the author with ID {authorID}.", ex);
            }
        }
    }
}
