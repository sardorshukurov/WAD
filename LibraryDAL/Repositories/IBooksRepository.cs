using System.Collections.Generic;
using WAD.Models;

namespace BookStoreAPI.Repositories
{
    public interface IBooksRepository
    {
        void InsertBook(Book book);
        void UpdateBook(int bookID, Book updatedBook);
        void DeleteBook(int bookID);
        Book GetBookByID(int bookID);
        IEnumerable<Book> GetBooks();
    }
}
