using CoursesApi.Data;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private AppDbContext _appDbContext;

        public CategoriesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory (Category category)
        {
            _appDbContext.Categories.Add(category);
            await _appDbContext.SaveChangesAsync();

            return Created();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await _appDbContext.Categories.ToListAsync();
            return Ok(categories);            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateCategory(int id, Category category)
        {
            var categoryUpdated = await _appDbContext.Categories.FindAsync(id);
            if (categoryUpdated is null)
                return NotFound();

            categoryUpdated.Name = category.Name;
            categoryUpdated.Status = category.Status;
            categoryUpdated.UpdatedAt = DateTime.Now;

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}