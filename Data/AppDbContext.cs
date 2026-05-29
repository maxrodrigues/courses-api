using CoursesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Course> Courses { get; set; }
    }
}