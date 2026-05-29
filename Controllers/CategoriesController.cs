using CoursesApi.Data;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}