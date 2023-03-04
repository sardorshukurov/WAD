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
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsRepository _authorsRepository;

        public AuthorsController(AuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            try
            {
                var authors = _authorsRepository.GetAuthors();
                return Ok(authors);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            try
            {
                var author = _authorsRepository.GetAuthorByID(id);
                return Ok(author);
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, Author author)
        {
            try
            {
                _authorsRepository.UpdateAuthor(id, author);
                return NoContent();
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Authors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Author> PostAuthor(Author author)
        {
            try
            {
                _authorsRepository.InsertAuthor(author);
                return CreatedAtAction(nameof(GetAuthor), new { id = author.ID }, author);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public ActionResult<Author> DeleteAuthor(int id)
        {
            try
            {
                _authorsRepository.DeleteAuthor(id);
                return NoContent();
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
