using System;
using System.Collections.Generic;

namespace balmoozdaq.Models
{
    public class Center
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Imgurl { get; set; }

        public List<Course> CourseList { get; set; }
    }
}
