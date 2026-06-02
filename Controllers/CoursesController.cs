using CoursesApi.Data;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var courseUpdated = await _appDbContext.Courses.FindAsync(id);
            if (courseUpdated is null)
                return NotFound();

            courseUpdated.CategoryId = course.CategoryId;
            courseUpdated.Name = course.Name;
            courseUpdated.Slug = course.Slug;
            courseUpdated.Description = course.Description;
            courseUpdated.Duration = course.Duration;
            courseUpdated.Price = course.Price;

            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

        public async Task<IActionResult> DeleteCourse (int id)
        {
            var course = await _appDbContext.Courses.FindAsync(id);
            if (course is null)
                return NotFound();
            
            _appDbContext.Courses.Remove(course);
            await _appDbContext.SaveChangesAsync();

            return NoContent();            
        }
    }
}