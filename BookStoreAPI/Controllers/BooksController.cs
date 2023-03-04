using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Exceptions;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.Data;
using WAD.Models;

namespace WAD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksRepository _booksRepository;

        public BooksController(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            try
            {
                var books = _booksRepository.GetBooks();
                return Ok(books);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

            // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            try
            {
                var book = _booksRepository.GetBookByID(id);
                return Ok(book);
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            try
            {
                _booksRepository.UpdateBook(id, book);
                return NoContent();
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            try
            {
                _booksRepository.InsertBook(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.ID }, book);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

            // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _booksRepository.DeleteBook(id);
                return NoContent();
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
