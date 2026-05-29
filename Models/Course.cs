using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public int Price { get; set; }

        public int Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}