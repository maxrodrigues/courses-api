using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoursesApi.Enums;

namespace CoursesApi.Models
{
    public class Category
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Course> Courses { get; } = [];

        public int Status { get; set; } = (int)CategoryStatus.Active;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}