using System;
using System.Collections.Generic;

namespace balmoozdaq.Models
{
    public class CourseType //добавляет админ
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Course> CourseList { get; set; }
    }
}
