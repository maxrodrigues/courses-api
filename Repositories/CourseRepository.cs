using CoursesApi.Data;
using CoursesApi.Models;
using CoursesApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;
    
    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Course> GetByIdAsync(int id)
    {
        return await _context.Courses.FindAsync(id);
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course is not null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}