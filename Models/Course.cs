using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoursesApi.Enums;

namespace CoursesApi.Models
{
    public class Course
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public int Price { get; set; }

        [JsonIgnore]
        public int Status { get; set; } = (int)CoursesStatus.Draft;
        
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}