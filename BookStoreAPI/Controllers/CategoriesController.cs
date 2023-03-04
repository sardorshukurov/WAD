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
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesController(CategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            try
            {
                var categories = _categoriesRepository.GetCategories();
                return Ok(categories);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            try
            {
                var category = _categoriesRepository.GetCategoryByID(id);
                return Ok(category);
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            try
            {
                _categoriesRepository.UpdateCategory(id, category);
                return NoContent();
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            try
            {
                _categoriesRepository.InsertCategory(category);
                return CreatedAtAction(nameof(GetCategory), new { id = category.ID }, category);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            try
            {
                _categoriesRepository.DeleteCategory(id);
                return NoContent();
            }
            catch (AppException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
