using CoursesApi.Data;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}