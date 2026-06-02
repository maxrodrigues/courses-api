using CoursesApi.Models;
using CoursesApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        
        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task <IActionResult> AddCourse (Course course)
        {
            await _courseRepository.AddAsync(course);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course courseUpdated)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course is null)
                return NotFound();
            
            await _courseRepository.UpdateAsync(courseUpdated);
            return NoContent();
        }

        public async Task<IActionResult> DeleteCourse (int id)
        {
            await _courseRepository.DeleteAsync(id);
            return NoContent();            
        }
    }
}