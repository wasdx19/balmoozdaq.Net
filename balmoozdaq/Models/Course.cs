using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace balmoozdaq.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }

        public List<CenterCourse> CenterCourses { get; set; }
    }
}
