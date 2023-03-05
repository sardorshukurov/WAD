using System.Collections.Generic;
using WAD.Models;

namespace BookStoreAPI.Repositories
{
    public interface IAuthorsRepository
    {
        void InsertAuthor(Author author);
        void UpdateAuthor(int authorID, Author updatedAuthor);
        void DeleteAuthor(int authorID);
        Author GetAuthorByID(int authorID);
        IEnumerable<Author> GetAuthors();
    }
}
