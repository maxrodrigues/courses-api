using CoursesApi.Data;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slugify;

namespace CoursesApi.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private AppDbContext _appDbContext;
        
        public CoursesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task <IActionResult> AddCourse (Course course)
        {
            _appDbContext.Courses.Add(course);
            await _appDbContext.SaveChangesAsync();
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _appDbContext.Courses.ToListAsync();
            return Ok(courses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            var helper = new SlugHelper();
            var courseUpdated = await _appDbContext.Courses.FindAsync(id);
            if (courseUpdated is null)
                return NotFound();

            courseUpdated.CategoryId = course.CategoryId;
            courseUpdated.Name = course.Name;
            courseUpdated.Slug = helper.GenerateSlug(course.Name);
            courseUpdated.Description = course.Description;
            courseUpdated.Duration = course.Duration;
            courseUpdated.Price = course.Price;

            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}