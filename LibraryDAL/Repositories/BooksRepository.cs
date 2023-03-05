using BookStoreAPI.Exceptions;
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
    public class BooksRepository : IBooksRepository
    {
        private readonly StoreContext _dbContext;

        public BooksRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteBook(int bookID)
        {
            Book book = _dbContext.Books.Find(bookID);
            if (book == null)
            {
                throw new AppException($"Book with ID {bookID} not found.");
            }
            try
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {

                throw new AppException($"An error occurred while deleting book with ID {bookID}.", ex); ;
            }
        }

        public Book GetBookByID(int bookID)
        {
            try
            {
                Book book = _dbContext.Books.Find(bookID);
                _dbContext.Entry(book).Reference(s => s.Category).Load();
                _dbContext.Entry(book).Reference(s => s.Author).Load();
                if (book == null)
                {
                    throw new AppException($"Book with ID {bookID} not found.");
                }
                return book;
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while retrieving book with ID {bookID}.", ex);
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            try
            {
                IEnumerable<Book> books = _dbContext.Books.Include(s => s.Category).Include(s => s.Author).ToList();
                if (books == null)
                {
                    throw new AppException($"Book are not found.");
                }
                return books;
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while retrieving books.", ex); ;
            }
        }

        public void InsertBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "The book parameter cannot be null.");
                }

                book.Category = _dbContext.Categories.Find(book.Category.ID);
                book.Author = _dbContext.Authors.Find(book.Author.ID);
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new AppException("An error occurred while inserting a new book.", ex);
            }
        }

        public void UpdateBook(int bookID, Book updatedBook)
        {
            try
            {
                Book book = _dbContext.Books.Find(bookID);
                if (book == null)
                {
                    throw new AppException($"Book with ID {bookID} not found.");
                }

                _dbContext.Entry(book).State = EntityState.Modified;

                book.Title = updatedBook.Title;
                book.Author = _dbContext.Authors.Find(updatedBook.Author.ID); ;
                book.Publisher = updatedBook.Publisher;
                book.PublicationDate = updatedBook.PublicationDate;
                book.ISBN = updatedBook.ISBN;
                book.Price = updatedBook.Price;
                book.Quantity = updatedBook.Quantity;
                book.Description = updatedBook.Description;
                book.Category = _dbContext.Categories.Find(updatedBook.Category.ID);
                book.Image = updatedBook.Image;
                book.Rating = updatedBook.Rating;

                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new AppException($"An error occurred while updating the book with ID {bookID}.", ex);
            }
        }
    }
}
