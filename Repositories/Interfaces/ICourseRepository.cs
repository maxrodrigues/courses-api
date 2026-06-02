using CoursesApi.Models;

namespace CoursesApi.Repositories.Interfaces;

public interface ICourseRepository
{
   Task<Course> GetByIdAsync(int id);
   Task<IEnumerable<Course>> GetAllAsync();
   Task AddAsync(Course course);
   Task UpdateAsync(Course course);
   Task DeleteAsync(int id);
}